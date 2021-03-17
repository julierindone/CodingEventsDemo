using System;
using System.Collections.Generic;
using System.Linq;
using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using CodingEventsDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CodingEventsDemo.Controllers
{
    public class EventCategoryController : Controller
    {
        private EventDbContext context;

        public EventCategoryController(EventDbContext context)
        {
           this.context = context;
        }

       
        public IActionResult Index()
        {
            List<EventCategory> eventCategories = context.EventCategories.ToList();
            return View(eventCategories);
        }

        [HttpGet]
        [Route("/EventCategory/Create/")]
        public IActionResult Create()
        {
            AddEventCategoryViewModel addEventCategories = new AddEventCategoryViewModel();

            return View(addEventCategories);      //this might be wrong.... maybe EventCategoryView?
        }

        [HttpPost]
        public IActionResult ProcessCreateEventCategoryForm(AddEventCategoryViewModel addEventCategories)    
        {

            if (ModelState.IsValid)
            {

                EventCategory newCategory = new EventCategory
                {
                    Name = addEventCategories.Name
                };

                context.EventCategories.Add(newCategory);
                context.SaveChanges();

                return Redirect("/EventCategory");
            }

            return View("Create", addEventCategories);            
        }
    }
}
