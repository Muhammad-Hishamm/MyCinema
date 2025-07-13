using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCinema.Data;

namespace MyCinema.Controllers
{
    public class ProducersController : Controller
    {
        private readonly AppDbContext _context; 
        public ProducersController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var ProducersList = await _context.Producers.ToListAsync();
            return View(ProducersList);
        }
    }
}
