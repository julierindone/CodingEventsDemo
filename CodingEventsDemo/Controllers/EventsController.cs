using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodingEventsDemo.Models;

namespace coding_events_practice.Controllers
{
    public class EventsController : Controller
    {
        static private List<Event>Events = new List<Event>();

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.events = Events;

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
            Events.Add(new Event(name, description));     //adding in a new Event object to use in the method        

            return Redirect("/Events");
        }
    }
}
