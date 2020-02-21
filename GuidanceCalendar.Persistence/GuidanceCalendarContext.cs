using GuidanceCalendar.Persistence.DAO;
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
        public DbSet<CalendarDao> Calendars { get; set; }
        public DbSet<StudentDao> Students { get; set; }
        public DbSet<TeacherDao> Teachers { get; set; }
        public DbSet<TimeslotDao> Timeslots { get; set; }
        public DbSet<BookingDao> Bookings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
