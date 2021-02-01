using System;
namespace CodingEventsDemo.Models
{
    public class Event
    {
        public string Name { get; set; }
        public string Description { get; }

        public int Id { get; set; }
        public static int nextId = 1;
        

        public Event(string name, string description)
        {
            Name = name;
            Description = description;
            Id = nextId;
            nextId++;
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
