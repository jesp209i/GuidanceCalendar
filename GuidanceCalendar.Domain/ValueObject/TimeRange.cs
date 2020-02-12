using System;
using System.Collections.Generic;
using System.Text;

namespace GuidanceCalendar.Domain.ValueObject
{
    public class TimeRange
    {
        public DateTimeOffset StartTime { get; private set; }
        public DateTimeOffset EndTime { get; private set; }
        public TimeSpan Duration { get; private set; }
        public TimeRange(DateTimeOffset startTime, DateTimeOffset endTime)
        {
            Guard(startTime, endTime);
            StartTime = startTime;
            EndTime = endTime;
            Duration = endTime.Subtract(startTime);
        }
        private void Guard(DateTimeOffset start, DateTimeOffset end)
        {
            if (end < start) throw new ArgumentOutOfRangeException("StartTime must be before EndTime");
        }
        public bool Overlap(TimeRange t2)
        {
            return (this.StartTime < t2.EndTime) && (this.EndTime > t2.StartTime);
        }
        public bool WithinBoundaries(TimeRange tr)
        {
            return (tr.StartTime >= StartTime && tr.EndTime <= )
        }
    }
}
