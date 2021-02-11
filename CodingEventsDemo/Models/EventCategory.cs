using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CodingEventsDemo.Models
{
    public class EventCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public EventCategory()
        {
        }

        public EventCategory(string name)
        {
            this.Name = name;
        }


        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            return obj is Event @event &&
                   Id == @event.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
