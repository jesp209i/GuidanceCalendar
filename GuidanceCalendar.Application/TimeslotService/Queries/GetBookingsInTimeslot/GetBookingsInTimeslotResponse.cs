using System;

namespace GuidanceCalendar.Application.TimeslotService.Queries.GetBookingsInTimeslot
{
    public class GetBookingsInTimeslotResponse
    {
        public Guid Id { get; set; }
        public DateTimeOffset BookingStartDateTime { get; set; }
        public DateTimeOffset BookingEndDateTime { get; set; }
        public Guid BookedBy { get; set; }
    }
}