using MediatR;
using System;
using System.Collections.Generic;

namespace GuidanceCalendar.Application.StudentService.Queries.UpcommingBookings
{
    public class UpcommingBookingsQuery : IRequest<List<UpcommingBookingsResponse>>
    {
        public Guid StudentId { get; set; }
    }
}