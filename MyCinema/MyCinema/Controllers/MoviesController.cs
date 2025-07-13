using Microsoft.AspNetCore.Mvc;
using MyCinema.Data;
using Microsoft.EntityFrameworkCore; 

namespace MyCinema.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _context;
        public MoviesController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var MoviesList = await _context.Movies.Include(movie=>movie.Cinema).ToListAsync();
            return View(MoviesList);
        }
    }
}
