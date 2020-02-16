using GuidanceCalendar.Domain.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GuidanceCalendar.Application.StudentService.Queries.GetBookingHistory
{
    public class GetBookingHistoryHandler : IRequestHandler<GetBookingHistoryQuery, List<GetBookingHistoryResponse>>
    {
        private readonly IStudentRepository studentRepository;

        public GetBookingHistoryHandler(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }
        public async Task<List<GetBookingHistoryResponse>> Handle(GetBookingHistoryQuery request, CancellationToken cancellationToken)
        {
            var response = new List<GetBookingHistoryResponse>();
            var student = await studentRepository.GetStudentWithBookingsById(request.StudentId);
            student.Bookings.ToList().ForEach(x => response.Add(new GetBookingHistoryResponse { Id = x.Id, BookingStartDateTime = x.StartTime, BookingEndDateTime = x.EndTime }));
            return response;
        }
    }
}
