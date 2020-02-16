using GuidanceCalendar.Domain;
using GuidanceCalendar.Domain.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GuidanceCalendar.Persistence.Repositories
{
    public class TeacherRepository : BaseRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(GuidanceCalendarContext dbContext) : base(dbContext)
        {
        }
    }
}
