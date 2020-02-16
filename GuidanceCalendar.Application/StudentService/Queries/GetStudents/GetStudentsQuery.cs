using MediatR;
using System.Collections.Generic;

namespace GuidanceCalendar.Application.StudentService.Queries.GetStudents
{
    public class GetStudentsQuery : IRequest<List<GetStudentsResponse>>
    {
    }
}