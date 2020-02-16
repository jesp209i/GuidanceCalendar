using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuidanceCalendar.Application.CalendarService.Queries.GetCalendar
{
    public class GetCalendarQuery : IRequest<GetCalendarResponse>
    {
        public Guid Id { get; set; }
    }
}
