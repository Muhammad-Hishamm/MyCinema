using MyCinema.Models;
using System.Collections.Generic;

namespace MyCinema.Data.Services.Actors

{
    public interface IActorServices
    {
        Task<IEnumerable<Actor>> GetAllAsync();
        Task<Actor> GetByIdAsync(int id);
        Task AddAsync(Actor actor);
        Task<Actor> UpdateAsync(int id, Actor actor);
        Task DeleteAsync(int id);
    }
}