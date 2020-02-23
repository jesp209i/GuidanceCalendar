using System;

namespace GuidanceCalendar.Application.UseCases.Calendar.Queries.AvaliableCalendars
{
    public class AvaliableCalendarsResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}