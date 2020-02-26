using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GuidanceCalendar.Application.UseCases.Calendar.Commands.CreateCalendar;
using GuidanceCalendar.Application.UseCases.Calendar.Queries.AvaliableCalendars;
using GuidanceCalendar.Application.UseCases.Calendar.Queries.GetCalendar;
using GuidanceCalendar.Domain;
using GuidanceCalendar.Ports.In.Application;
using MediatR;

namespace GuidanceCalendar.Application.Port.In
{
    public class CalendarService : ApplicationService, ICalendarService
    {
        public CalendarService(IMediator mediator) : base(mediator)
        {
        }

        public async Task<Guid> CreateCalendar(string name, string description)
        {
            return await _mediator.Send(new CreateCalendarCommand { Name = name, Description = description });
        }

        public async Task<ICollection<Calendar>> GetAvailableCalendars()
        {
            return await _mediator.Send(new AvaliableCalendarsRequest());
        }

        public async Task<Calendar> GetCalendar(Guid id)
        {
            return await _mediator.Send(new GetCalendarQuery { Id = id });
        }
    }
}
