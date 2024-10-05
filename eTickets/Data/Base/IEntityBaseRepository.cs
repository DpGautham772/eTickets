using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        // void Add(Actor actor);
        Task UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);
        Task AddAsync(T entity);

    }
}