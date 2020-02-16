using GuidanceCalendar.Domain;
using GuidanceCalendar.Domain.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GuidanceCalendar.Persistence.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(GuidanceCalendarContext dbContext) : base(dbContext)
        {
        }
    }
}
