using GuidanceCalendar.Domain.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GuidanceCalendar.Application.StudentService.Queries.UpcommingBookings
{
    public class UpcommingBookingsHandler : IRequestHandler<UpcommingBookingsQuery, List<UpcommingBookingsResponse>>
    {
        private readonly IStudentRepository studentRepository;

        public UpcommingBookingsHandler(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }
        public async Task<List<UpcommingBookingsResponse>> Handle(UpcommingBookingsQuery request, CancellationToken cancellationToken)
        {
            var response = new List<UpcommingBookingsResponse>();
            var student = await studentRepository.GetStudentWithBookingsById(request.StudentId);
            student.GetOpenBookings().ToList().ForEach(x => response.Add(new UpcommingBookingsResponse { Id = x.Id, BookingStartDateTime = x.StartTime, BookingEndDateTime = x.EndTime }));
            return response;
        }
    }
}
