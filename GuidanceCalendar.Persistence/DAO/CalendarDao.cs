using GuidanceCalendar.Persistence.DAO.Common;
using System;
using System.Collections.Generic;

namespace GuidanceCalendar.Persistence.DAO
{
    public class CalendarDao : AbstractEntityDao
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public ICollection<TimeslotDao> AvailableTimeslots { get; private set; }

    }
}
