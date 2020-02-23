using GuidanceCalendar.Persistence.DAO;
using GuidanceCalendar.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GuidanceCalendar.Persistence.Repositories
{
    public class TeacherRepository : BaseRepository<TeacherDao>, ITeacherRepository
    {
        public TeacherRepository(GuidanceCalendarContext dbContext) : base(dbContext)
        {
        }

        public async Task<TeacherDao> GetTeacherWithTimeslotsById(Guid id)
        {
            return await dbSet.Where(x => x.Id == id).Include(x => x.AvailableTimeslots).FirstOrDefaultAsync();

        }
    }
}
