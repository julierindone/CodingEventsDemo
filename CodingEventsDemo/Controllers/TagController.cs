using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using CodingEventsDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEventsDemo.Controllers
{
    public class TagController : Controller
    {
        private EventDbContext context;

        public TagController(EventDbContext context)
        {
            this.context = context;
        }
        
        public IActionResult Index()
        {
            List<Tag> tags = context.Tags.ToList();  
                
            return View(tags);
        }

        [HttpGet]
        [Route("/Tag/Create/")]
        public IActionResult Create()
        {
            AddTagViewModel addTag = new AddTagViewModel();
            return View(addTag);
        }

        ///////////NOT WORKING YET/////////////
        [HttpPost]
        //Route tag?
        public IActionResult ProcessCreateTag(AddTagViewModel addTag)
        {
            if (ModelState.IsValid)
            {
                Tag newTag = new Tag
                {
                    Name = addTag.Name
                };

                context.Tags.Add(newTag);
                context.SaveChanges();

                return Redirect("/Tag");
            }
            return View(addTag);
        }
    }
}
