using GuidanceCalendar.Domain.Common;
using System.Collections.Generic;

namespace GuidanceCalendar.Domain
{
    public class Student : Entity
    {
        public string Name { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public Student()
        {
            Bookings = new List<Booking>();
        }
    }
}