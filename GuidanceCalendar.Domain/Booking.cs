using GuidanceCalendar.Domain.Common;
using System;

namespace GuidanceCalendar.Domain
{
    public class Booking : TimeRange
    {
        public Student BookedBy { get; private set; }
        public Booking(Student booker, DateTimeOffset startTime, DateTimeOffset endTime)
        {
            BookedBy = booker;
            TimeRangeGuard(startTime, endTime);
            StartTime = startTime;
            EndTime = endTime;
        }

    }
}