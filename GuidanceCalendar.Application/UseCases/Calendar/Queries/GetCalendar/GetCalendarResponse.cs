using System;

namespace GuidanceCalendar.Application.UseCases.Calendar.Queries.GetCalendar
{
    public class GetCalendarResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}