using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCinema.Data.Services.Producers;
using MyCinema.Models;

namespace MyCinema.Data.Services.Producers
{
    public class ProducerServices : IProducerServices
    {
        private readonly AppDbContext _context;

        public ProducerServices(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Producer producer)
        {
            await _context.AddAsync(producer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var producer = await _context.Producers.FirstOrDefaultAsync(x => x.Id == id);
            _context.Producers.Remove(producer);
            await _context.SaveChangesAsync();
        }

        public async Task<Producer> GetByIdAsync(int id)
        {
            var producer = await _context.Producers.FirstOrDefaultAsync(act => act.Id == id);
            return producer;

        }

        public async Task<IEnumerable<Producer>> GetAllAsync()
        {
            var producers = await _context.Producers.ToListAsync();
            return producers;
        }

        public async Task<Producer> UpdateAsync(int id, Producer producer)
        {
            _context.Update(producer);
            await _context.SaveChangesAsync();
            return producer;
        }
    }
}
