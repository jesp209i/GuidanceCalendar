using GuidanceCalendar.Domain.Interfaces.Persistence;
using MediatR;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GuidanceCalendar.Application.TeacherService.Queries.GetAvailableTimeslots
{
    public class GetAvailableTimeslotsHandler : IRequestHandler<GetAvailableTimeslotsQuery, List<GetAvailableTimeslotsResponse>>
    {
        private readonly ITeacherRepository teacherRepository;

        public GetAvailableTimeslotsHandler(ITeacherRepository teacherRepository)
        {
            this.teacherRepository = teacherRepository;
        }
        public async Task<List<GetAvailableTimeslotsResponse>> Handle(GetAvailableTimeslotsQuery request, CancellationToken cancellationToken)
        {
            var teacher = await teacherRepository.GetTeacherWithTimeslotsById(request.TeacherId);
            var response = new List<GetAvailableTimeslotsResponse>();
            teacher.AvailableTimeslots.ToList().ForEach(x => response.Add(new GetAvailableTimeslotsResponse { Id = x.Id, SlotStartDateTime = x.StartTime, SlotEndDateTime = x.EndTime }));
            return response;
        }
    }
}
