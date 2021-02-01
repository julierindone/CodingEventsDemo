using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEventsDemo.Models;   ///////I had to add this in order for Event object to be accepted.//////

namespace CodingEventsDemo.Data
{

    //////////This went really fast and a lot of it didn't make a ton of sense to me.////////////
    public class EventData
    {
        //store events   
            // 1. recreating the events collection that we'd made 

        private static Dictionary<int, Event> Events = new Dictionary <int, Event>();      
            //static bc we're not creating instancesm just dealing w the class itself

        // add events
        public static void Add(Event newEvent)       //public method bc we want to use it to interact w the dictionary. We will add the new event being created to the collection (Dictionary) every time this method is called.         
        {
            Events.Add(newEvent.Id, newEvent);
        }

        //retrieve the events - list
        public  static IEnumerable<Event> GetAll()   //This is a interface of type Event list
        {
                return Events.Values;    //when we query this collection of events for this information, what we want returned are the events themselves, NOT a list with ids attached as keys. So it's returning a list of events... it's called ?
        }

        //retrieve a single event
        public static Event GetById(int id)      //It's going to return the Event object that matches the ID being asked for
        {
                return Events[id];    //using the key itself to return that value ---why are we using lowercase? why is it letting us? How is it knowing what to retrieve? if both key and value were integers how would it know?
        }

        //remove an event

    }
}
