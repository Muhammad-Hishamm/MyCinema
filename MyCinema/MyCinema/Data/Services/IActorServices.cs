using MyCinema.Models;

namespace MyCinema.Data.Services
{
    public interface IActorServices
    {
        Task<IEnumerable<Actor>> GetAllActorsAsync();
        Task<Actor> GetActorByIdAsync(int id);
        Task AddAsync(Actor actor);
        Task<Actor> UpdateAsync(int id, Actor actor);
        void Delete(int id);
    }
}
