using System;
using CodingEventsDemo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using CodingEventsDemo.Models.NewFolder;
using Microsoft.EntityFrameworkCore;

namespace CodingEventsDemo.Data
{
    public class EventDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<EventTag> EventTags { get; set; } 



        //The code below is to configure the EventTags table for the combined PK/identifier. 
        protected override void OnModelCreating(ModelBuilder modelBuilder)  
        {
            modelBuilder.Entity<EventTag>()
                  .HasKey(et => new { et.EventId, et.TagId });

            base.OnModelCreating(modelBuilder);
        }


        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {
        }
    }
}
