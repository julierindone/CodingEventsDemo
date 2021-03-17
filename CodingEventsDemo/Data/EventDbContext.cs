using System;
using CodingEventsDemo.Models;
//using CodingEventsDemo.Models.NewFolder;
using Microsoft.EntityFrameworkCore;

namespace CodingEventsDemo.Data
{
    public class EventDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public DbSet<EventTag> EventTags { get; set; }   // isn't recognizing that i took EventTags out of the NewFolder I made by accident, maybe a restart will change that.

        //The code below is to configure the EventTags table for the combined PK/identifier. 
        protected override void OnModelCreating(ModelBuilder modelBuilder)  
        {
            modelBuilder.Entity<EventTag>()
                  .HasKey(et => new { et.EventId, et.TagId });
        }


        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {
        }
    }
}
