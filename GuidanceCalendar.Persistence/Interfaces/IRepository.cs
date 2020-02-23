using GuidanceCalendar.Persistence.DAO.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuidanceCalendar.Persistence.Interfaces
{
    public interface IRepository<T> where T: AbstractEntityDao
    {
        Task<T> AddAsync(T entity);
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> ListAsync();
        Task Update(T entityToUpdate);
    }
}
