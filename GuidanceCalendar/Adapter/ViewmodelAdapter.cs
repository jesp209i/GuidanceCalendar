using GuidanceCalendar.API.Viewmodels;
using GuidanceCalendar.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuidanceCalendar.API.Adapter
{
    public class ViewmodelAdapter
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
    }
}
