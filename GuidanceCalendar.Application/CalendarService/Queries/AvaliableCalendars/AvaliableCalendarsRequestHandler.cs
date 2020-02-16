using GuidanceCalendar.Domain.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace GuidanceCalendar.Application.CalendarService.Queries.AvaliableCalendars
{
    public class AvaliableCalendarsRequestHandler : IRequestHandler<AvaliableCalendarsRequest, List<AvaliableCalendarsResponse>>
    {
        private readonly ICalendarRepository calendarRepository;

        public AvaliableCalendarsRequestHandler(ICalendarRepository calendarRepository)
        {
            this.calendarRepository = calendarRepository;
        }
        public async Task<List<AvaliableCalendarsResponse>> Handle(AvaliableCalendarsRequest request, CancellationToken cancellationToken)
        {
            var availableCalendars = await calendarRepository.ListAsync();
            var response = new List<AvaliableCalendarsResponse>();
            availableCalendars.ToList().ForEach(x => response.Add(new AvaliableCalendarsResponse { Id = x.Id, Name = x.Name, Description = x.Description }));
            return response;


        }
    }
}
