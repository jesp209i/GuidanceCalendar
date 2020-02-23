using System;
using System.Collections.Generic;
using GuidanceCalendar.Persistence.DAO.Common;

namespace GuidanceCalendar.Persistence.DAO
{
    public class TimeslotDao : AbstractEntityDao
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ICollection<BookingDao> Bookings { get; set; }
        public TeacherDao TimeslotOwner { get; set; }
        public CalendarDao Calendar { get; set; }
    }
}
