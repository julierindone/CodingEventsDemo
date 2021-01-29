using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEventsDemo.Models
{
    public class Event     //what used to be a dictionary with two strings is now an object with a name property!
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Event(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

        public override string ToString()
        {
            return this.Name;
        }



    }
}
