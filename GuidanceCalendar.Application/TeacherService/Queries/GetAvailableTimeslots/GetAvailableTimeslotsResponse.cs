using System;

namespace GuidanceCalendar.Application.TeacherService.Queries.GetAvailableTimeslots
{
    public class GetAvailableTimeslotsResponse
    {
        public DateTimeOffset SlotStartDateTime { get; set; }
        public DateTimeOffset SlotEndDateTime { get; set; }
        public Guid Id { get; set; }
    }
}