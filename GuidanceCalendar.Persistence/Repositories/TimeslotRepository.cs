using GuidanceCalendar.Domain;
using GuidanceCalendar.Domain.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GuidanceCalendar.Persistence.Repositories
{
    public class TimeslotRepository : BaseRepository<Timeslot>, ITimeslotRepository
    {
        public TimeslotRepository(GuidanceCalendarContext dbContext) : base(dbContext)
        {
        }

        public async Task<Timeslot> GetTimeslotWithBookingsById(Guid id)
        {
            return await dbSet.Include(ts => ts.Bookings).FirstOrDefaultAsync(ts => ts.Id == id);
        }
    }
}
