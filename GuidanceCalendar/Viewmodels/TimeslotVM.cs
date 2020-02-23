using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuidanceCalendar.API.Viewmodels
{
    public class TimeslotVM
    {
        public Guid Id { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
    }
}
