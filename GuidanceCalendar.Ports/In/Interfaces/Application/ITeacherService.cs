using GuidanceCalendar.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GuidanceCalendar.Ports.In.Interfaces.Application
{
    public interface ITeacherService
    {
        // Commands
        Task<Guid> CreateTimeslot(
            Guid teacherId,
            Guid calendarId,
            DateTimeOffset startTime,
            DateTimeOffset endTime);

        // Queries
        Task<ICollection<Timeslot>> GetAvailableTimeslotsByTeacherId(Guid TeacherId);
        Task<ICollection<Teacher>> GetTeachers();

    }
}
