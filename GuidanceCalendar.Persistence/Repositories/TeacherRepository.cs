using GuidanceCalendar.Domain;
using GuidanceCalendar.Domain.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GuidanceCalendar.Persistence.Repositories
{
    public class TeacherRepository : BaseRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(GuidanceCalendarContext dbContext) : base(dbContext)
        {
        }

        public async Task<Teacher> GetTeacherWithTimeslotsById(Guid id)
        {
            return await dbSet.Where(x => x.Id == id).Include(x => x.AvailableTimeslots).FirstOrDefaultAsync();

        }
    }
}
