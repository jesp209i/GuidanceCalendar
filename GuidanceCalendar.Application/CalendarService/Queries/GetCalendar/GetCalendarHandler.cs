using GuidanceCalendar.Domain.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GuidanceCalendar.Application.CalendarService.Queries.GetCalendar
{
    public class GetCalendarHandler : IRequestHandler<GetCalendarQuery, GetCalendarResponse>
    {
        private readonly ICalendarRepository calendarRepository;

        public GetCalendarHandler(ICalendarRepository calendarRepository)
        {
            this.calendarRepository = calendarRepository;
        }
        public async Task<GetCalendarResponse> Handle(GetCalendarQuery request, CancellationToken cancellationToken)
        {
            var calendar = await calendarRepository.GetByIdAsync(request.Id);
            return new GetCalendarResponse { Id = calendar.Id, Description = calendar.Description, Name = calendar.Name };
        }
    }
}
