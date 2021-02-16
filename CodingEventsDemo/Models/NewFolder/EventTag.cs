using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEventsDemo.Models.NewFolder
{
    public class EventTag
    {
        public int EventId { get; set; }
        public Event Event { get; set; }

        public int TagId { get; set; }

    }
}
