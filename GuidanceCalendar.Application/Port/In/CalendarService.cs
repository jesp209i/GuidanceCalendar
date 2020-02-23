using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GuidanceCalendar.Ports.In.Interfaces.Application;

namespace GuidanceCalendar.Application.Port.In
{
    public class CalendarService : ICalendarService
    {
        public Task<Guid> CreateCalendar(string name, string description)
        {
            throw new NotImplementedException();
        }
    }
}
