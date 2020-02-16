using System;

namespace GuidanceCalendar.Application.CalendarService.Queries.AvaliableCalendars
{
    public class AvaliableCalendarsResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}