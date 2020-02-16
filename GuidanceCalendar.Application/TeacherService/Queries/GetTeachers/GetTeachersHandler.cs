using GuidanceCalendar.Domain.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace GuidanceCalendar.Application.TeacherService.Queries.GetTeachers
{
    public class GetTeachersHandler : IRequestHandler<GetTeachersQuery, List<GetTeachersResponse>>
    {
        private readonly ITeacherRepository teacherRepository;

        public GetTeachersHandler(ITeacherRepository teacherRepository)
        {
            this.teacherRepository = teacherRepository;
        }
        public async Task<List<GetTeachersResponse>> Handle(GetTeachersQuery request, CancellationToken cancellationToken)
        {
            var teachers = await teacherRepository.ListAsync();
            var response = new List<GetTeachersResponse>();
            teachers.ToList().ForEach(x => response.Add(new GetTeachersResponse { Id = x.Id, Name = x.Name }));
            return response;
        }
    }
}
