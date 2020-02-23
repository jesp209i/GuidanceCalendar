using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuidanceCalendar.Application.UseCases.Calendar.Commands.CreateCalendar
{
    public class CreateCalendarCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
