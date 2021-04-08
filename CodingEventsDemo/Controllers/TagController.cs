using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using CodingEventsDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEventsDemo.Controllers
{ 
    public class TagController : Controller
    {
        private EventDbContext context;

        public TagController(EventDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Tag> tags = context.Tags.ToList();

            return View(tags);
        }



        [HttpGet]
        public IActionResult Create()
        {
        AddTagViewModel addTag = new AddTagViewModel();
        return View(addTag);
        }
        //!!!!!commenting out LC's to try Ben's again!!!!   
        /*public IActionResult Create()
            {   
            Tag tag = new Tag();
            return View(tag);*/
        

        [HttpPost]
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

                return Redirect("/Tag/");
            }
            return View("Create", addTag);
        }

        //We need this id because it's going to say "/TagEvent/Id/" we need to know which event the user want to add a tag to.
        [Route("/Tag/AddEvent/")]  //took the star off the end here...
        public IActionResult AddEvent(int id)
        {
            Event theEvent = context.Events.Find(id);
            List<Tag> possibleTags = context.Tags.ToList();

            AddEventTagViewModel viewModel = new AddEventTagViewModel(theEvent, possibleTags);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddEvent(AddEventTagViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                int eventId = viewModel.EventId;
                int tagId = viewModel.TagId;

                List<EventTag> existingItems = context.EventTags
                    .Where(et => et.EventId == eventId)
                    .Where(et => et.TagId == tagId)
                    .ToList();

                if (existingItems.Count == 0)
                {

                    EventTag eventTag = new EventTag
                    {
                        EventId = eventId,
                        TagId = tagId
                    };

                    context.EventTags.Add(eventTag);
                    context.SaveChanges();
                }
                return Redirect("/Events/Detail/" + eventId);
            }

            return View(viewModel);
        }

        public IActionResult Detail(int id)
        {
            List<EventTag> eventTags = context.EventTags
                .Where(et => et.TagId == id)
                .Include(et => et.Event)
                .Include(et => et.Tag)
                .ToList();

            return View(eventTags);
            }
    }
}
