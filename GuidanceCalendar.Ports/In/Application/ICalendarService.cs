using GuidanceCalendar.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuidanceCalendar.Ports.In.Application
{
    public interface ICalendarService
    {
        // Commands
        Task<Guid> CreateCalendar(
            string name,
            string description);
        Task<Calendar> GetCalendar(Guid id);
        Task<ICollection<Calendar>> GetAvailableCalendars();
    }
}
