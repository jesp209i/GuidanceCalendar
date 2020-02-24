using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuidanceCalendar.API.Viewmodels.Commands
{
    public class CreateTimeslotCommand
    {
        public Guid TeacherId { get; set; }
        public Guid CalendarId { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
    }
}
