using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using CodingEventsDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;

// We're creating a way to edit events.

namespace coding_events_practice.Controllers
{
    public class EventsController : Controller
    {

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Event> events = new List<Event>(EventData.GetAll());

            return View(events);
        }

        public IActionResult Add()
        {
            AddEventViewModel addEventViewModel = new AddEventViewModel();
            return View(addEventViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddEventViewModel addEventViewModel)
        {
            if (ModelState.IsValid)
            //View model is valid:
            {
                Event newEvent = new Event
                {
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    ContactEmail = addEventViewModel.ContactEmail    
                };

                EventData.Add(newEvent);

                return Redirect("/Events");
            } 

            return View(addEventViewModel);

        }
        
        //Get: /Events/Edit/{eventID}
        [HttpGet]
        [Route("/events/edit/{eventId}")]     //inputs the ID of the edit we need to do up into the Route.

        public IActionResult Edit(int eventId)
        {
                //we need to make a editEventViewModel object with properties assigned from the Event associated with that specific eventId.
            Event eventToEdit = EventData.GetById(eventId);         //this is holding the object we're editing. like declaring a variable. We have to do this because when we create the objkect below we have to pass it an Event.

                //Use eventToEdit to populate values of editEventViewModel
            EditEventViewModel editEventViewModel = new EditEventViewModel(eventToEdit);

            return View(editEventViewModel);  //this displays the form to edit the event chosen in Event.cshtml
        }

                //Post /Events/Edit/
        [HttpPost]

        public IActionResult Edit(EditEventViewModel viewModel)
        {
            if (ModelState.IsValid)  //deal with validations! edit can only happen if fields pass validation.
            {
                //how does the post request know which id we're lookinh at?
                //get the Event object from Event Data
                // where does the eventId come from? it's stored in the viewModel.
                Event eventToEdit = EventData.GetById(viewModel.Id);    //grabbing our eventToEdit from eventData by calling GetById (inside of viewModel.Id).

                //Modify properties in eventToEdit using newest values stored in viewModel.
                            //we need to have the ID here... we use a "hidden input" in the Edit.cshtml so it's a post-request parameter.
                eventToEdit.Name = viewModel.Name;
                eventToEdit.Description = viewModel.Description;
                eventToEdit.ContactEmail = viewModel.ContactEmail;

                return Redirect("/Events/");      //user sent back to /Events

            }
                //if not valid"
            return View(viewModel);
            
        }











        public IActionResult Delete()
        {
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
