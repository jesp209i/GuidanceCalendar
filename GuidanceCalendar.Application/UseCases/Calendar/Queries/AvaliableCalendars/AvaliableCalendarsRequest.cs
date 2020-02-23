using GuidanceCalendar.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuidanceCalendar.Application.UseCases.Calendar.Queries.AvaliableCalendars
{
    public class AvaliableCalendarsRequest : IRequest<ICollection<Domain.Calendar>>
    {
    }
}
