using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GuidanceCalendar.Domain.Interfaces.Persistence
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<Student> GetStudentWithBookingsById(Guid id);
    }
}
