using GuidanceCalendar.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace GuidanceCalendar.Persistence
{
    public class GuidanceCalendarContext : DbContext
    {
        public GuidanceCalendarContext(DbContextOptions<GuidanceCalendarContext> options) : base(options)
        {
        }
        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Timeslot> Timeslots { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
