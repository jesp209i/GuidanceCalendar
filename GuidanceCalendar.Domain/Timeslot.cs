using GuidanceCalendar.Domain.Common;
using GuidanceCalendar.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuidanceCalendar.Domain
{
    public class Timeslot : Entity
    {
        public DateTimeOffset SlotStartDateTime { get => TimeRange.StartTime; }
        public DateTimeOffset SlotEndDateTime { get => TimeRange.EndTime; }
        public TimeRange TimeRange { get; set; }
        public ICollection<Booking> Bookings { get; private set; }
        public Teacher TimeslotOwner { get; private set; }
        public Calendar Calendar { get; set; }
        public Timeslot(DateTimeOffset startTime, DateTimeOffset endTime, Teacher owner, Calendar calendar)
        {
            Bookings = new List<Booking>();
            TimeRange = new TimeRange(startTime, endTime);
            TimeslotOwner = owner;
            Calendar = calendar;
        }

        public bool Overlap(Timeslot timeslot)
        {
            return this.TimeRange.Overlap(timeslot.TimeRange);
        }
    }
}
