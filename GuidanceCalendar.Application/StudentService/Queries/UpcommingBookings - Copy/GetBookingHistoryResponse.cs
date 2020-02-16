using System;

namespace GuidanceCalendar.Application.StudentService.Queries.GetBookingHistory
{
    public class GetBookingHistoryResponse
    {
        public Guid Id { get; set; }
        public DateTimeOffset BookingStartDateTime { get; set; }
        public DateTimeOffset BookingEndDateTime { get; set; }
    }
}