using MediatR;
using System;
using System.Collections.Generic;

namespace GuidanceCalendar.Application.TimeslotService.Queries.GetBookingsInTimeslot
{
    public class GetBookingsInTimeslotQuery : IRequest<List<GetBookingsInTimeslotResponse>>
    {
        public Guid TimeslotId { get; set; }
    }
}