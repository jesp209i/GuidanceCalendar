using GuidanceCalendar.Peristence.DAO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GuidanceCalendar.Persistence.DAO
{
    public class StudentDao
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<BookingDao> Bookings { get; set; }

    }
}