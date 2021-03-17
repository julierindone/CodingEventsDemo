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
        [StringLength(50, MinimumLength = 2)]
        public string Name { get;set;}

    }
}
