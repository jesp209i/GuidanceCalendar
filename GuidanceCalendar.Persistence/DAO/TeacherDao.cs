using GuidanceCalendar.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GuidanceCalendar.Persistence.DAO
{
    public class TeacherDao
    {
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public ICollection<TimeslotDao> AvailableTimeslots { get; private set; }
        public ICollection<CalendarDao> Calendars { get; private set; }        
    }
}