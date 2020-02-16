using GuidanceCalendar.Domain.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GuidanceCalendar.Application.StudentService.Queries.GetStudents
{
    public class GetStudentsHandler : IRequestHandler<GetStudentsQuery, List<GetStudentsResponse>>
    {
        private readonly IStudentRepository studentRepository;

        public GetStudentsHandler(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }
        public async Task<List<GetStudentsResponse>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            var response = new List<GetStudentsResponse>();
            var students = await studentRepository.ListAsync();
            students.ToList().ForEach(x => response.Add(new GetStudentsResponse { Id = x.Id, Name = x.Name }));
            return response;
        }
    }
}
