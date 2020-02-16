using GuidanceCalendar.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GuidanceCalendar.Domain
{
    public class Student : Entity
    {
        public string Name { get; private set; }
        public ICollection<Booking> Bookings { get; private set; }
        public Student(string name)
        {
            Bookings = new List<Booking>();
            Name = name;
        }
        private void BookingGuard()
        {
            var thisMoment = DateTime.UtcNow;
            if (Bookings.Count(b => b.StartTime > ThisMoment()) == 2) throw new Exception("You can only have two open bookings");                
        }
        private DateTimeOffset ThisMoment() => DateTime.UtcNow;
        public void AddBooking(Booking booking)
        {
            BookingGuard();
            Bookings.Add(booking);
        }
        public ICollection<Booking> GetOpenBookings()
        {
            return Bookings.Where(b => b.StartTime > ThisMoment()).ToList();
        }

    }
}