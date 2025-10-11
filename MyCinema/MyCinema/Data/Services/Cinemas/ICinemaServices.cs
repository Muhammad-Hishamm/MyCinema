using MyCinema.Models;

namespace MyCinema.Data.Services.Cinemas
{
    public interface ICinemaServices
    {
        Task<IEnumerable<Cinema>> GetAllAsync();
        Task<Cinema> GetByIdAsync(int id);
        Task AddAsync(Cinema cinema);
        Task<Cinema> UpdateAsync(int id, Cinema cinema);
        Task DeleteAsync(int id);
    }
}