using MediatR;
using System;
using System.Collections.Generic;

namespace GuidanceCalendar.Application.TeacherService.Queries.GetAvailableTimeslots
{
    public class GetAvailableTimeslotsQuery : IRequest<List<GetAvailableTimeslotsResponse>>
    {
        public Guid TeacherId { get; set; }
    }
}