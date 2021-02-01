using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodingEventsDemo.Models;
using CodingEventsDemo.Data;

namespace coding_events_practice.Controllers
{
    public class EventsController : Controller
    {
        //static private List<Event> Events = new List<Event>();

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.events = EventData.GetAll();

            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("Events/Add")]
        //revised NewEvent method to create a Model of the Event class called newEvent instead of passing in the parameters string name & string descrption. We had to go check the form to make sure model field names(properties in Data/Event.cs) match the form field names. (see notes in Add.cshtml)
        public IActionResult NewEvent(Event newEvent)    //parameter is now newEvent 
        {
            EventData.Add(newEvent);     

            return Redirect("/Events");
        }

        //[HttpGet]
        public IActionResult Delete()
        {
            ViewBag.events = EventData.GetAll();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)  //<-- IDs of checkboxes clicked for deletion
        {
            foreach (int eventId in eventIds)  //dif from launchcode solution but should still work
            {
                EventData.Remove(eventId);
            }

            return Redirect("/Events");

            /////////////my items aren't actually deleting from the last!
        }

        public IActionResult Edit(int[] eventIds)
        {
            ViewBag.events = EventData.GetById(id);

        }

        [HttpPost]
        [Route("/EventsController/Edit/*/")]
        public IActionResult SubmitEditEventForm(int eventID, string name, string description)
        {

        }
    }
}

/*

foreach (int eventId in eventIds)
{
    
}*/