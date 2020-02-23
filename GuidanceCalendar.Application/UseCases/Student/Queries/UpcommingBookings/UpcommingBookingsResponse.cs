using System;

namespace GuidanceCalendar.Application.StudentService.Queries.UpcommingBookings
{
    public class UpcommingBookingsResponse
    {
        public Guid Id { get; set; }
        public DateTimeOffset BookingStartDateTime { get; set; }
        public DateTimeOffset BookingEndDateTime { get; set; }
    }
}