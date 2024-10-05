using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTickets.Data.Base;
using eTickets.Models;
using eTickets.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService
    {
        private readonly AppDbContext _context;

        public ActorsService(AppDbContext context) : base(context) { }
        // {
        //     _context = context;
        // }
        // public void Add(Actor actor)
        // {
        //     _context.Actors.Add(actor);
        //     _context.SaveChanges();
        // }

        // public async Task AddAsync(Actor actor)
        // {
        //     await _context.Actors.AddAsync(actor);  // Add actor to the context
        //     await _context.SaveChangesAsync();  // Save changes asynchronously
        // }

        // public async Task DeleteAsync(int id)
        // {
        //     var result = await _context.Actors.FirstOrDefaultAsync(n => n.Id == id);
        //     _context.Actors.Remove(result);
        //     await _context.SaveChangesAsync();
        // }

        // public async Task<IEnumerable<Actor>> GetAllAsync()
        // {
        //     var result = await _context.Actors.ToListAsync();
        //     return result;
        // }

        // public async Task<Actor> GetByIdAsync(int id)
        // {
        //     var result = await _context.Actors.FirstOrDefaultAsync(n => n.Id == id);
        //     return result;
        // }

        // public async Task<Actor> UpdateAsync(int id, Actor newActor)
        // {
        //     _context.Update(newActor);
        //     await _context.SaveChangesAsync();
        //     return newActor;
        // }
    }
}