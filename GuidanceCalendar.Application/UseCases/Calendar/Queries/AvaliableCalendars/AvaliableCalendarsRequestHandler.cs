using GuidanceCalendar.Domain;
using GuidanceCalendar.Ports.Out.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GuidanceCalendar.Application.UseCases.Calendar.Queries.AvaliableCalendars
{
    public class AvaliableCalendarsRequestHandler : IRequestHandler<AvaliableCalendarsRequest, ICollection<Domain.Calendar>>
    {
        private readonly ICalendarPersistencePort _cpp;

        public AvaliableCalendarsRequestHandler(ICalendarPersistencePort cpp)
        {
            this._cpp = cpp;
        }
        public async Task<ICollection<Domain.Calendar>> Handle(AvaliableCalendarsRequest request, CancellationToken cancellationToken)
        {
            return await _cpp.ListCalendarsAsync();
        }
    }
}
