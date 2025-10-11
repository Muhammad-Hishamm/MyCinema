using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCinema.Models;

namespace MyCinema.Data.Services.Cinemas
{
    public class CinemaServices : ICinemaServices
    {
        private readonly AppDbContext _context;

        public CinemaServices(AppDbContext context) {
            _context = context;
        }
        public async Task AddAsync(Cinema cinema)
        {
            await _context.AddAsync(cinema);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cinema = await _context.Cinemas.FirstOrDefaultAsync(x => x.Id == id); 
            _context.Cinemas.Remove(cinema);
            await _context.SaveChangesAsync();
        }

        public async Task<Cinema> GetByIdAsync(int id)
        {
            var cinema = await _context.Cinemas.FirstOrDefaultAsync(c =>  c.Id == id);
            return cinema;
            
        }

        public async Task<IEnumerable<Cinema>> GetAllAsync()
        {
            var cinemas = await _context.Cinemas.ToListAsync();
            return cinemas;
        }

        public async Task<Cinema> UpdateAsync(int id, Cinema cinema)
        {
            _context.Update(cinema);
            await _context.SaveChangesAsync();
            return cinema;
        }
    }
}
