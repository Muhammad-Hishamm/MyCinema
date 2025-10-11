using MyCinema.Models;

namespace MyCinema.Data.Services.Producers
{
    public interface IProducerServices
    {
        Task<IEnumerable<Producer>> GetAllAsync();
        Task<Producer> GetByIdAsync(int id);
        Task AddAsync(Producer producer);
        Task<Producer> UpdateAsync(int id, Producer newProducer);
        Task DeleteAsync(int id);

        
    }
}
