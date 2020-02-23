
using GuidanceCalendar.Persistence.DAO;
using GuidanceCalendar.Persistence.DAO.Common;
using System;

namespace GuidanceCalendar.Persistence.DAO
{
    public class BookingDao : AbstractEntityDao
    {
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public StudentDao BookedBy { get; set; }
    }
}