using System;
using System.ComponentModel.DataAnnotations;
using CodingEventsDemo.Models;

namespace CodingEventsDemo.ViewModels
{
    public class EditEventViewModel
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]  ////with error message)

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, ErrorMessage = "Description is too long!")]
        public string Description { get; set; }

        [EmailAddress]
        public string ContactEmail { get; set; }

        public EditEventViewModel() { }  //we need an empty constructor so that viewModel (in controller) works. this is requirement of model binding.

        public EditEventViewModel(Event evt)      //constructor that can take in an event object and create instance of EditEventViewModel
        {
            this.Id = evt.Id;
            this.Name = evt.Name;
            this.Description = evt.Description;
            this.ContactEmail = evt.ContactEmail;
        }

    }
}
