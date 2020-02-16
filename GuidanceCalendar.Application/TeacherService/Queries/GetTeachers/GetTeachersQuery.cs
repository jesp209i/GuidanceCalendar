using MediatR;
using System.Collections.Generic;

namespace GuidanceCalendar.Application.TeacherService.Queries.GetTeachers
{
    public class GetTeachersQuery : IRequest<List<GetTeachersResponse>>
    {
    }
}