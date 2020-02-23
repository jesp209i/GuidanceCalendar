using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GuidanceCalendar.Persistence.DAO.Common;
using GuidanceCalendar.Persistence.Interfaces;

namespace GuidanceCalendar.Persistence.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : AbstractEntityDao
    {
        private readonly GuidanceCalendarContext dbContext;
        protected DbSet<T> dbSet;
        protected BaseRepository(GuidanceCalendarContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
        }
        public async Task<T> AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var entity = await dbSet.FirstOrDefaultAsync(ent => ent.Id == id);
            if (entity == null)
            {
                throw new Exception($"{typeof(T).Name} was not found");
            }
            return entity;
        }

        public async Task<IEnumerable<T>> ListAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task Update(T entityToUpdate)
        {
            dbContext.Entry(entityToUpdate).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
