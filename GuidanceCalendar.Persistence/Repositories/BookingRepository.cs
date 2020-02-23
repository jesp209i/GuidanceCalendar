using GuidanceCalendar.Persistence.DAO;
using GuidanceCalendar.Persistence.Interfaces;

namespace GuidanceCalendar.Persistence.Repositories
{
    public class BookingRepository : BaseRepository<BookingDao>, IBookingRepository
    {
        public BookingRepository(GuidanceCalendarContext dbContext) : base(dbContext)
        {
        }
    }
}
