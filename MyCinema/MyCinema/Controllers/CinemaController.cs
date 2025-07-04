using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCinema.Data;

namespace MyCinema.Controllers
{
    public class CinemaController : Controller
    {
        private readonly AppDbContext _context;
        public CinemaController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _context.Cinemas.ToListAsync();
            return View();
        }
    }
}
