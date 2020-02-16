using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuidanceCalendar.Application.CalendarService.Queries.AvaliableCalendars
{
    public class AvaliableCalendarsRequest : IRequest<List<AvaliableCalendarsResponse>>
    {
    }
}
