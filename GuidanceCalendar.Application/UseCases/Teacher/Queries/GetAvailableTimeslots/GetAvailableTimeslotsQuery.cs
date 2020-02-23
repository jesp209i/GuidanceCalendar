using GuidanceCalendar.Domain;
using MediatR;
using System;
using System.Collections.Generic;

namespace GuidanceCalendar.Application.UseCases.Teacher.Queries.GetAvailableTimeslots
{
    public class GetAvailableTimeslotsQuery : IRequest<ICollection<Timeslot>>
    {
        public Guid TeacherId { get; set; }
    }
}