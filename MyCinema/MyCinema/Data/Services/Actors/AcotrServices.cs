using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCinema.Models;

namespace MyCinema.Data.Services.Actors
{
    public class ActorServices : IActorServices
    {
        private readonly AppDbContext _context;

        public ActorServices(AppDbContext context) {
            _context = context;
        }
        public async Task AddAsync(Actor actor)
        {
            await _context.AddAsync(actor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var actor = await _context.Actors.FirstOrDefaultAsync(x => x.Id == id); 
            _context.Actors.Remove(actor);
            await _context.SaveChangesAsync();
        }

        public async Task<Actor> GetByIdAsync(int id)
        {
            var actor = await _context.Actors.FirstOrDefaultAsync(act =>  act.Id == id);
            return actor;
            
        }

        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            var actors = await _context.Actors.ToListAsync();
            return actors;
        }

        public async Task<Actor> UpdateAsync(int id, Actor actor)
        {
            _context.Update(actor);
            await _context.SaveChangesAsync();
            return actor;
        }
    }
}
