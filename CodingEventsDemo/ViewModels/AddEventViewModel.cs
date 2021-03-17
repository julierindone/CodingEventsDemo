using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CodingEventsDemo.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CodingEventsDemo.ViewModels
{
    public class AddEventViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description too long!")]
        public string Description { get; set; }

        [EmailAddress]
        public string ContactEmail { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }

        public List<SelectListItem> EventCategories { get; set; }

        public AddEventViewModel()
        {
        }

        public AddEventViewModel(List<EventCategory> categories)
        {
            EventCategories = new List<SelectListItem>();

            foreach (var category in categories)
            {
                EventCategories.Add(
                    new SelectListItem
                {
                    Value = category.Id.ToString(),    //we want the user to see the category name, but have it use the ID.
                    Text = category.Name
                });                       
            }
        }
    }
}
