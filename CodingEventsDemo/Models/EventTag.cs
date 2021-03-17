using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEventsDemo.Models
{
    public class EventTag
        //this is a JOIN table.        
        ////We have to specify that our unique identifier/PK for this class will be a combo of the EventId and TagId.
    {
        public int EventId { get; set; }
        public Event Event { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }           //object reference to the tag itself... WHY?

        public EventTag()
        {
        }
    }
}
