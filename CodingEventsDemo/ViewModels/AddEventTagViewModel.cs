using CodingEventsDemo.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEventsDemo.ViewModels
{
    public class AddEventTagViewModel
    {
        public int EventId { get; set; }
        public Event Event { get; set; }

        //dropdown list of available tags:
        public List<SelectListItem> Tags { get; set; }
        public int TagId { get; set; } //WTF is this for????

        public AddEventTagViewModel(Event theEvent, List<Tag> possibleTags)   //for now it needs to configure the Event object and tAgs collction. (I might have fixed this... leaving note in case of later problems.
        {
            Tags = new List<SelectListItem>();

            foreach (var tag in possibleTags)
            {
                Tags.Add(new SelectListItem
                {
                    Value = tag.Id.ToString(), //Value is the data sent to server. Text is what's displayed in the drop-down.
                    Text = tag.Name
                });
            }

            Event = theEvent;   ///not sure about this.
        }

        public AddEventTagViewModel()
        {
        }
    }
}
