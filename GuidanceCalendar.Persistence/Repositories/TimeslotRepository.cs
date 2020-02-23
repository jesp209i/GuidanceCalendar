using GuidanceCalendar.Persistence.DAO;
using GuidanceCalendar.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace GuidanceCalendar.Persistence.Repositories
{
    public class TimeslotRepository : BaseRepository<TimeslotDao>, ITimeslotRepository
    {
        public TimeslotRepository(GuidanceCalendarContext dbContext) : base(dbContext)
        {
        }

        public async Task<TimeslotDao> GetTimeslotWithBookingsById(Guid id)
        {
            return await dbSet.Include(ts => ts.Bookings).FirstOrDefaultAsync(ts => ts.Id == id);
        }
    }
}
