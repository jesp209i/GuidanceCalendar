using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GuidanceCalendar.Domain.Interfaces.Persistence
{
    public interface ITimeslotRepository : IRepository<Timeslot>
    {
        Task<Timeslot> GetTimeslotWithBookingsById(Guid id);
    }
}
