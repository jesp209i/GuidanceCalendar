using GuidanceCalendar.Domain.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuidanceCalendar.Domain.Interfaces.Persistence
{
    public interface IRepository<T> where T: Entity
    {
        Task<T> AddAsync(T entity);
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> ListAsync();
        Task Update(T entityToUpdate);
    }
}
