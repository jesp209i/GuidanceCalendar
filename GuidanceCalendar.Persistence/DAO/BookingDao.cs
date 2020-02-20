
using GuidanceCalendar.Persistence.DAO;
using System;

namespace GuidanceCalendar.Persistence.DAO
{
    public class BookingDao
    {
        public Guid Id { get; set; }
        DateTimeOffset StartTime { get; set; }
        DateTimeOffset EndTime { get; set; }
        public StudentDao BookedBy { get; set; }
    }
}