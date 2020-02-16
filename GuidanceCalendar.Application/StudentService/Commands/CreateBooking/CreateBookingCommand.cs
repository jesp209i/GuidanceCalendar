using MediatR;
using System;

namespace GuidanceCalendar.Application.StudentService.Commands.CreateBooking
{
    public class CreateBookingCommand : IRequest<CreateBookingResponse>
    {
        public Guid TimeslotId { get; set; }
        public DateTimeOffset BookingStartDateTime { get; set; }
        public DateTimeOffset BookingEndDateTime { get; set; }
        public Guid StudentId { get; set; }
    }
}