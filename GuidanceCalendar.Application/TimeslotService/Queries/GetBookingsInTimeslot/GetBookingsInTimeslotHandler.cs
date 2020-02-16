using GuidanceCalendar.Domain.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GuidanceCalendar.Application.TimeslotService.Queries.GetBookingsInTimeslot
{
    public class GetBookingsInTimeslotHandler : IRequestHandler<GetBookingsInTimeslotQuery, List<GetBookingsInTimeslotResponse>>
    {
        private readonly ITimeslotRepository timeslotRepository;

        public GetBookingsInTimeslotHandler(ITimeslotRepository timeslotRepository)
        {
            this.timeslotRepository = timeslotRepository;
        }
        public async Task<List<GetBookingsInTimeslotResponse>> Handle(GetBookingsInTimeslotQuery request, CancellationToken cancellationToken)
        {
            var timeslot = await timeslotRepository.GetTimeslotWithBookingsById(request.TimeslotId);
            var response = new List<GetBookingsInTimeslotResponse>();
            timeslot.Bookings.ToList().ForEach(x =>
            {
                response.Add(new GetBookingsInTimeslotResponse { Id = x.Id, BookingStartDateTime = x.StartTime, BookingEndDateTime = x.EndTime });
            });
            return response;
        }
    }
}
