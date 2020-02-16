using GuidanceCalendar.Domain;
using GuidanceCalendar.Domain.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GuidanceCalendar.Application.StudentService.Commands.CreateBooking
{
    public class CreateBookingHandler : IRequestHandler<CreateBookingCommand, CreateBookingResponse>
    {
        private readonly IStudentRepository studentRepository;
        private readonly ITimeslotRepository timeslotRepository;

        public CreateBookingHandler(IStudentRepository studentRepository, ITimeslotRepository timeslotRepository)
        {
            this.studentRepository = studentRepository;
            this.timeslotRepository = timeslotRepository;
        }
        public async Task<CreateBookingResponse> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var timeslot = await timeslotRepository.GetTimeslotWithBookingsById(request.TimeslotId);
            var student = await studentRepository.GetStudentWithBookingsById(request.StudentId);
            var booking = new Booking(student, request.BookingStartDateTime, request.BookingEndDateTime);
            timeslot.AddBooking(booking);
            await timeslotRepository.Update(timeslot);
            return new CreateBookingResponse { Id = booking.Id };
        }
    }
}
