using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuidanceCalendar.Application.TeacherService.Commands.CreateTimeslot
{
    public class CreateTimeslotCommand : IRequest<CreateTimeslotResponse>
    {
        public Guid TeacherId { get; set; }
        public Guid CalendarId { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
    }
}
