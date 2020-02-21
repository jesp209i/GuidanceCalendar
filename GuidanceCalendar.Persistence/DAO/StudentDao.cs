using GuidanceCalendar.Persistence.DAO.Common;
using System.Collections.Generic;

namespace GuidanceCalendar.Persistence.DAO
{
    public class StudentDao : AbstractEntityDao
    {
        public string Name { get; set; }
        public ICollection<BookingDao> Bookings { get; set; }
    }
}