using GuidanceCalendar.Persistence.DAO;
using GuidanceCalendar.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace GuidanceCalendar.Persistence.Repositories
{
    public class StudentRepository : BaseRepository<StudentDao>, IStudentRepository
    {
        public StudentRepository(GuidanceCalendarContext dbContext) : base(dbContext)
        {
        }

        public async Task<StudentDao> GetStudentWithBookingsById(Guid id)
        {
            var rightNow = DateTime.UtcNow;
            return await dbSet.Include(s => s.Bookings).FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
