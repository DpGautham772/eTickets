using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IActorsService : IEntityBaseRepository<Actor>
    {
        // Task<IEnumerable<Actor>> GetAllAsync();
        // Task<Actor> GetByIdAsync(int id);
        // // void Add(Actor actor);
        // Task<Actor> UpdateAsync(int id, Actor newActor);
        // Task DeleteAsync(int id);
        // Task AddAsync(Actor actor);
    }
}