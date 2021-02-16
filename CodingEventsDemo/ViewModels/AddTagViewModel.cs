using CodingEventsDemo.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEventsDemo.ViewModels
{
    public class AddTagViewModel
    {
        [Required]
        [StringLength(50, MinimumLength =2)]
        public string Name { get;set;}

        public int TagId { get; set; }

        public List<SelectListItem> Tags { get; set; }

        public AddTagViewModel()
        {
        }

        public AddTagViewModel(List<Tag> tags)
        {
            Tags = new List<SelectListItem>();

            foreach(var tag in tags)
            {
                Tags.Add(
                    new SelectListItem
                    {
                        Value = tag.Id.ToString(),
                        Text = tag.Name
                    }); 
            }
        }
    }
}
