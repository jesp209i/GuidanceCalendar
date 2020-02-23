using GuidanceCalendar.Persistence.DAO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GuidanceCalendar.Persistence.Interfaces
{
    public interface ITimeslotRepository : IRepository<TimeslotDao>
    {
        Task<TimeslotDao> GetTimeslotWithBookingsById(Guid id);
    }
}
