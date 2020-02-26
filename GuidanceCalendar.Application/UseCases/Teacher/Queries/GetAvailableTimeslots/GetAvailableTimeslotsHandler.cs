using MediatR;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GuidanceCalendar.Domain;
using GuidanceCalendar.Ports.Out.Persistence;

namespace GuidanceCalendar.Application.UseCases.Teacher.Queries.GetAvailableTimeslots
{
    public class GetAvailableTimeslotsHandler : IRequestHandler<GetAvailableTimeslotsQuery, ICollection<Timeslot>>
    {
        private readonly ITeacherPersistencePort _tpp;

        public GetAvailableTimeslotsHandler(ITeacherPersistencePort tpp)
        {
            this._tpp = tpp;
        }
        public async Task<ICollection<Timeslot>> Handle(GetAvailableTimeslotsQuery request, CancellationToken cancellationToken)
        {
            var teacher = await _tpp.GetTeacherWithTimeslotsById(request.TeacherId);

            return teacher.AvailableTimeslots;
        }
    }
}
