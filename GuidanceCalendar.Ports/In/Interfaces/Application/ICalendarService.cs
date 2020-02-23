using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GuidanceCalendar.Ports.In.Interfaces.Application
{
    public interface ICalendarService
    {
        // Commands
        Task<Guid> CreateCalendar(
            string name,
            string description);
    }
}
