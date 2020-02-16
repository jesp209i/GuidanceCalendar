using MediatR;
using System;
using System.Collections.Generic;

namespace GuidanceCalendar.Application.StudentService.Queries.GetBookingHistory
{
    public class GetBookingHistoryQuery : IRequest<List<GetBookingHistoryResponse>>
    {
        public Guid StudentId { get; set; }
    }
}