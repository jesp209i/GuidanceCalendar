using GuidanceCalendar.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using GuidanceCalendar.Ports.Out;

namespace GuidanceCalendar.Application.UseCases.Teacher.Queries.GetTeachers
{
    public class GetTeachersHandler : IRequestHandler<GetTeachersQuery, ICollection<Domain.Teacher>>
    {
        private readonly ITeacherPersistencePort _tpp;

        public GetTeachersHandler(ITeacherPersistencePort tpp)
        {
            
            this._tpp = tpp;
        }
        public async Task<ICollection<Domain.Teacher>> Handle(GetTeachersQuery request, CancellationToken cancellationToken)
        {
            return await _tpp.ListTeachersAsync(); 
        }
    }
}
