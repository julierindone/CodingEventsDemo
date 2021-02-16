using CodingEventsDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEventsDemo.ViewModels
{
    //viewmodel that will be the @model PageModel for a Details view
    public class EventDetailViewModel
    {
        public string Name { get; set; } 
        public string Description { get; set; }
        public string ContactEmail { get; set; }
        public string CategoryName { get; set; }

        public EventDetailViewModel(Event theEvent)    //Ben used "evt" instead of "theEvent".
        {
            Name = theEvent.Name;
            Description = theEvent.Description;
            ContactEmail = theEvent.ContactEmail;
            CategoryName = theEvent.Category.Name;
        }
    }
}
