using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEventsDemo.Models;

namespace CodingEventsDemo.Data
{
    public class EventData
    {
        // store events - first we're recreating the events collection
        private static Dictionary<int, Event> Events = new Dictionary<int, Event>();

        // add events
        public static void Add(Event newEvent)
        {
            Events.Add(newEvent.Id, newEvent);
        }

        //retrieve events  <-- this allows us to access ALL the events outside of this class
        public static IEnumerable<Event> GetAll()         // <-- review interfaces!! 
        {
            return Events.Values;          // <-- we JUST want the values.
        }

        //retrieve a single event
        public static Event GetByID(int id)
        {
            return Events[id];
        }
       
        //remove an event
        public static void Remove(int id)
        {
            Events.Remove(id);
        }
    }
}
