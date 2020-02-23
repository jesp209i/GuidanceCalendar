using GuidanceCalendar.Persistence.DAO;
using GuidanceCalendar.Persistence.Interfaces;

namespace GuidanceCalendar.Persistence.Repositories
{
    public class CalendarRepository : BaseRepository<CalendarDao>, ICalendarRepository
    {
        public CalendarRepository(GuidanceCalendarContext dbContext) : base(dbContext)
        {
        }
    }
}
