using GuidanceCalendar.Domain;
using Microsoft.EntityFrameworkCore;
using System;


namespace GuidanceCalendar.Persistence
{
    public class CalendarContext : DbContext
    {
        public CalendarContext(DbContextOptions<CalendarContext> options) : base(options)
        {
        }
        public DbSet<Calendar> Calendars { get; set; }
    }
}
