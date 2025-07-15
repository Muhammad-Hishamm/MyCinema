using MyCinema.Models;

namespace MyCinema.Data.Services
{
    public interface IActorServices
    {
        Task<IEnumerable<Actor>> GetAllActors();
        Actor GetActor(int id);
        void Add(Actor actor);
        Actor Update(int id, Actor actor);
        void Delete(int id);
    }
}
