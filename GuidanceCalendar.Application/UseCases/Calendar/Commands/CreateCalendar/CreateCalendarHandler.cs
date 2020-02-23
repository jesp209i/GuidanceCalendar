using GuidanceCalendar.Domain;
using GuidanceCalendar.Persistence.Interfaces;
using GuidanceCalendar.Ports.Out;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GuidanceCalendar.Application.UseCases.Calendar.Commands.CreateCalendar
{
    public class CreateCalendarHandler : IRequestHandler<CreateCalendarCommand, Guid>
    {
        private readonly ICalendarPersistencePort _cpp;

        public CreateCalendarHandler(ICalendarPersistencePort cpp)
        {
            this._cpp = cpp;
        }
        public async Task<Guid> Handle(CreateCalendarCommand request, CancellationToken cancellationToken)
        {
            var newCalendar = new Domain.Calendar(request.Name, request.Description);
            return await _cpp.AddCalendarAsync(newCalendar);
        }
    }
}
