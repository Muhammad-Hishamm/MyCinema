using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCinema.Models;

namespace MyCinema.Data.Services
{
    public class AcotrServices : IActorServices
    {
        private readonly AppDbContext _context;

        public AcotrServices(AppDbContext context) {
            _context = context;
        }
        public async Task AddAsync(Actor actor)
        {
            await _context.AddAsync(actor);
            await _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Actor> GetActorByIdAsync(int id)
        {
            var actor = await _context.Actors.FirstOrDefaultAsync(act =>  act.Id == id);
            return actor;
            
        }

        public async Task<IEnumerable<Actor>> GetAllActorsAsync()
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
