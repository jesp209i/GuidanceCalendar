using GuidanceCalendar.Domain;
using GuidanceCalendar.Domain.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GuidanceCalendar.Persistence.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(GuidanceCalendarContext dbContext) : base(dbContext)
        {
        }

        public async Task<Student> GetStudentWithBookingsById(Guid id)
        {
            var rightNow = DateTime.UtcNow;
            return await dbSet.Include(s => s.Bookings).FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
