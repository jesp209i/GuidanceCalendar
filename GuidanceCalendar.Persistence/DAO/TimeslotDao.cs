using System;
using System.Collections.Generic;
using GuidanceCalendar.Persistence.DAO.Common;

namespace GuidanceCalendar.Persistence.DAO
{
    public class TimeslotDao : AbstractEntityDao
    {
        public ICollection<BookingDao> Bookings { get; private set; }
        public TeacherDao TimeslotOwner { get; private set; }
        public CalendarDao Calendar { get; set; }
    }
}
