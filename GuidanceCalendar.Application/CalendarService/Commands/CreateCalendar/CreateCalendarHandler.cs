using GuidanceCalendar.Domain;
using GuidanceCalendar.Domain.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GuidanceCalendar.Application.CalendarService.Commands.CreateCalendar
{
    public class CreateCalendarHandler : IRequestHandler<CreateCalendarCommand, CreateCalendarResponse>
    {
        private readonly ICalendarRepository calendarRepository;

        public CreateCalendarHandler(ICalendarRepository calendarRepository)
        {
            this.calendarRepository = calendarRepository;
        }
        public async Task<CreateCalendarResponse> Handle(CreateCalendarCommand request, CancellationToken cancellationToken)
        {
            var newCalendar = new Calendar(request.Name, request.Description);
            await calendarRepository.AddAsync(newCalendar);
            return new CreateCalendarResponse { Id = newCalendar.Id };
            
        }
    }
}
