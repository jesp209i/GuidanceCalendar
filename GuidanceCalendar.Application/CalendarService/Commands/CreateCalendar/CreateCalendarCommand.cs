using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuidanceCalendar.Application.CalendarService.Commands.CreateCalendar
{
    public class CreateCalendarCommand : IRequest<CreateCalendarResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
