using GuidanceCalendar.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GuidanceCalendar.Ports.Out
{
    public interface ITeacherPersistencePort
    {
        Task<Teacher> GetTeacherWithTimeslotsById(Guid teacherId);
        Task<ICollection<Teacher>> ListTeachersAsync();
        Task Update(Teacher updateTeacher);
    }
}
