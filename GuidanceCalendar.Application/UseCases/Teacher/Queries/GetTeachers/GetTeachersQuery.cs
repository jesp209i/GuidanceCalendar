using MediatR;
using System.Collections.Generic;

namespace GuidanceCalendar.Application.UseCases.Teacher.Queries.GetTeachers
{
    public class GetTeachersQuery : IRequest<ICollection<Domain.Teacher>>
    {
    }
}