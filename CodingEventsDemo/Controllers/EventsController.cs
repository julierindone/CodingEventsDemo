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
        public IActionResult NewEvent(string name, string description)
        {
            EventData.Add(new Event(name, description));     //adding in a new Event object to use in the method        

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
    }
}
