using GuidanceCalendar.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuidanceCalendar.Ports.Out
{
    public interface ICalendarPersistencePort
    {
        Task<Calendar> GetByIdAsync(Guid id);
        Task<ICollection<Calendar>> ListCalendarsAsync();
        Task<Guid> AddCalendarAsync(Calendar calendar);
    }
}
