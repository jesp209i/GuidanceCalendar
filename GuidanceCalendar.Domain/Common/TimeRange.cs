using System;
using System.Collections.Generic;
using System.Text;

namespace GuidanceCalendar.Domain.Common
{
    public abstract class TimeRange : Entity
    {
        public DateTimeOffset StartTime { get; protected set; }
        public DateTimeOffset EndTime { get; protected set; }
        public TimeSpan Duration { get=> EndTime.Subtract(StartTime); }
        protected void TimeRangeGuard(DateTimeOffset start, DateTimeOffset end)
        {
            if (end < start) throw new ArgumentOutOfRangeException("StartTime must be before EndTime");
        }
        public void OverlapGuard(TimeRange t2)
        {
            if ((this.StartTime < t2.EndTime) && (this.EndTime > t2.StartTime)) throw new Exception("Dont overlap");
        }
        public void BoundaryGuard(TimeRange tr)
        {
            if (tr.StartTime < StartTime && tr.EndTime > EndTime) throw new Exception("Stay within boundary");
        }
    }
}
