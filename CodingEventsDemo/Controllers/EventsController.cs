using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using Microsoft.AspNetCore.Mvc;
using CodingEventsDemo.ViewModels;

namespace coding_events_practice.Controllers
{
    public class EventsController : Controller
    {

        // GET: /<controller>/
        public IActionResult Index()
        {
            //ViewBag.events = EventData.GetAll();   <-- getting rid of ViewBag; creating a list of Events
            List<Event> events = new List<Event>(EventData.GetAll());

            return View(events);  //<--passng the events list into the View as an argument to turn the view into a Razor view page based on an object.
        }


        //[HttpGet]
        public IActionResult Add()
        {
            //creat blank addeventviewmodel to associate with the Form in Add.cshtml
            AddEventViewModel addEventViewModel = new AddEventViewModel();

            return View(addEventViewModel);
        }

        //"You feed it into the Get request empty, and it comes out full in the Post."

        //we can rename this "Add" bc they have different argument signatures. The Get has 0, Post has 2.


        [HttpPost]
        //now we take the filled adEventViewModel and use it to create a new Event object. ***we translate the info in the object into the info we want in the database.***
        public IActionResult Add(AddEventViewModel addEventViewModel) 
        {
            Event newEvent = new Event     //new curly brace syntax lets us assign properties here
            {
                Name = addEventViewModel.Name,
                Description = addEventViewModel.Description
            };

            EventData.Add(newEvent);
      
            return Redirect("/Events");
        }

        public IActionResult Delete()
        {
            //ViewBag.title = "Delete Events";
            ViewBag.events = EventData.GetAll();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach (int eventId in eventIds)
            {
                EventData.Remove(eventId);
            }

            return Redirect("/Events");
        }
    }
}
