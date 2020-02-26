using GuidanceCalendar.Ports.Out.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace GuidanceCalendar.Application.UseCases.Calendar.Queries.GetCalendar
{
    public class GetCalendarHandler : IRequestHandler<GetCalendarQuery, Domain.Calendar>
    {
        private readonly ICalendarPersistencePort _cpp;

        public GetCalendarHandler(ICalendarPersistencePort cpp)
        {
            _cpp = cpp;
        }
        public async Task<Domain.Calendar> Handle(GetCalendarQuery request, CancellationToken cancellationToken)
        {
            return await _cpp.GetByIdAsync(request.Id);
        }
    }
}
