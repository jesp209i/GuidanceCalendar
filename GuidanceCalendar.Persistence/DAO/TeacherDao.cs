using GuidanceCalendar.Domain.Common;
using GuidanceCalendar.Persistence.DAO.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GuidanceCalendar.Persistence.DAO
{
    public class TeacherDao : AbstractEntityDao
    {
        public string Name { get; private set; }
        public ICollection<TimeslotDao> AvailableTimeslots { get; private set; }
        public ICollection<CalendarDao> Calendars { get; private set; }        
    }
}