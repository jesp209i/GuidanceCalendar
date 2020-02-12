using GuidanceCalendar.Domain.Common;
using GuidanceCalendar.Domain.ValueObject;
using System;

namespace GuidanceCalendar.Domain
{
    public class Booking : Entity
    {
        public DateTimeOffset BookingStartDateTime { get => TimeRange.StartTime; }
        public DateTimeOffset BookingEndDateTime { get => TimeRange.EndTime; }
        public Student BookedBy { get; private set; }
        public TimeRange TimeRange { get; private set; }
        public Booking(Student booker, DateTimeOffset startTime, DateTimeOffset endTime)
        {
            BookedBy = booker;
            TimeRange = new TimeRange(startTime, endTime);
        }
        public bool Overlap(Booking booking)
        {
            return this.TimeRange.Overlap(booking.TimeRange);
        }
    }
}