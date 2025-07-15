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
        public void Add(Actor actor)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Actor GetActor(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Actor>> GetAllActors()
        {
            var actors = await _context.Actors.ToListAsync();
            return actors;
        }

        public Actor Update(int id, Actor actor)
        {
            throw new NotImplementedException();
        }
    }
}
