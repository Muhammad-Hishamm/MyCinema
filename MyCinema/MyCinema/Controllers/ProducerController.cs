using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCinema.Data;

namespace MyCinema.Controllers
{
    public class ProducerController : Controller
    {
        private readonly AppDbContext _context; 
        public ProducerController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var data =await _context.Producers.ToListAsync();
            return View();
        }
    }
}
