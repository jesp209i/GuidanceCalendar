using GuidanceCalendar.API.Viewmodels;
using GuidanceCalendar.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuidanceCalendar.API.Mapper
{
    public class ViewmodelMapper
    {
        internal object ConvertToTimeslotsDTO(ICollection<Timeslot> timeslots)
        {
            List<TimeslotVM> vmTimeslots = new List<TimeslotVM>();
            timeslots.ToList().ForEach(x => vmTimeslots.Add(new TimeslotVM { Id = x.Id, StartTime = x.StartTime, EndTime = x.EndTime }));
            return vmTimeslots;
        }

        internal object ConvertToTeachersDTO(ICollection<Teacher> teachers)
        {
            List<TeacherVM> vmTeachers = new List<TeacherVM>();
            teachers.ToList().ForEach(x => vmTeachers.Add(new TeacherVM { Name = x.Name, Id = x.Id }));
            return vmTeachers;
        }

        internal object ConvertToCalendarListDTO(ICollection<Calendar> calendars)
        {
            List<CalendarVM> vmCalendars = new List<CalendarVM>();
            calendars.ToList().ForEach(x => vmCalendars.Add(new CalendarVM { Id = x.Id, Name = x.Name, Description = x.Description }));
            return vmCalendars;
        }
    }
}
