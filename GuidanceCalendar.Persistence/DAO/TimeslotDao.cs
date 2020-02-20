﻿using GuidanceCalendar.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GuidanceCalendar.Persistence.DAO
{
    public class TimeslotDao
    {
        public ICollection<Booking> Bookings { get; private set; }
        public Teacher TimeslotOwner { get; private set; }
        public Calendar Calendar { get; set; }
        public TimeslotDao()
        {

        }
        public TimeslotDao(DateTimeOffset startTime, DateTimeOffset endTime, Teacher owner, Calendar calendar)
        {
            Bookings = new List<Booking>();
            TimeRangeGuard(startTime, endTime);
            StartTime = startTime;
            EndTime = endTime;
            TimeslotOwner = owner;
            Calendar = calendar;
        }

        public void AddBooking(Booking booking)
        {
            foreach(var book in Bookings)
            {
                book.OverlapGuard(booking);
            }
            booking.BookedBy.AddBooking(booking);
            Bookings.Add(booking);
        }
    }
}
