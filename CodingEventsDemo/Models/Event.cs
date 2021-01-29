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

        public int Id { get; }
        private static int nextId = 1;    //private; lowercase bc it's a field - won't be used as a property. static bc it's not dependent on any instance data

        public Event(string name, string description)
        {
            this.Name = name;
            this.Description = description;
            this.Id = nextId;
            nextId++;
        }

        public override string ToString()
        {
            return this.Name;
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
