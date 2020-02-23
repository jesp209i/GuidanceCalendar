using GuidanceCalendar.Ports.Out;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace GuidanceCalendar.Application.UseCases.Calendar.Queries.GetCalendar
{
    public class GetCalendarHandler : IRequestHandler<GetCalendarQuery, GetCalendarResponse>
    {
        private readonly ICalendarPersistencePort _cpp;

        public GetCalendarHandler(ICalendarPersistencePort cpp)
        {
            _cpp = cpp;
        }
        public async Task<GetCalendarResponse> Handle(GetCalendarQuery request, CancellationToken cancellationToken)
        {
            var calendar = await _cpp.GetByIdAsync(request.Id);
            return new GetCalendarResponse { Id = calendar.Id, Description = calendar.Description, Name = calendar.Name };
        }
    }
}
