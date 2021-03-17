using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using CodingEventsDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;  //changed building to this one.


namespace coding_events_practice.Controllers
{
    public class EventsController : Controller
    {

        //private readonly EventDbContext context;
        private EventDbContext context;

        public EventsController(EventDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Event> events = context.Events
                .Include(e => e.Category).ToList();

            return View(events);
        }

        public IActionResult Add()
        {
            AddEventViewModel addEventViewModel = new AddEventViewModel(context.EventCategories.ToList());

            return View(addEventViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddEventViewModel addEventViewModel)
        {
            if (ModelState.IsValid)
            {
                EventCategory category = context.EventCategories.Find(addEventViewModel.CategoryId);
                Event newEvent = new Event
                {
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    ContactEmail = addEventViewModel.ContactEmail,
                    Category = category
                };

                context.Events.Add(newEvent);
                context.SaveChanges();

                return Redirect("/Events");
            }

            return View(addEventViewModel);
        }

        public IActionResult Delete()
        {
            ViewBag.events = context.Events.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach (int eventId in eventIds)
            {
                Event theEvent = context.Events.Find(eventId);
                context.Events.Remove(theEvent);
            }

            context.SaveChanges();

            return Redirect("/Events");
        }

        public IActionResult Detail(int id) //I think Ben called this "Details."  
                //they pass in id for the event via a query parameter, or as a route parameter.
                    //Events/Detail?id=5 ---OR--- Events/Detail/5
        {
            Event theEvent = context.Events    //this came from the EventDetailViewModel.
                .Include(e => e.Category)      //these create eager loading.
                .Single(e => e.Id == id);      //this ensures all entries with that id is printed? this would be more important if we were trying to match all entries that start with letter b.

            List<EventTag> eventTags = context.EventTags
                .Where(et => et.EventId == id)  //we only want to filter out tags with this event id .
                .Include(et => et.Tag)       //since EventTag has properties that are refs from other tables, we must eagerly load them to be included.
                .ToList();              //Then we put in a list.
                                                     
            EventDetailViewModel viewModel = new EventDetailViewModel(theEvent, eventTags);
            return View(viewModel);


        }


    }
}
