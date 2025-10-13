using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCinema.Data;
using MyCinema.Data.Services.Cinemas;
using MyCinema.Data.Services.Producers;
using MyCinema.Models;

namespace MyCinema.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemaServices _services;
        public CinemasController(ICinemaServices services)
        {
            _services = services;
        }

        public async Task<IActionResult> Index()
        {
            var CenimasList = await _services.GetAllAsync();
            return View(CenimasList);
        }

        // create new producer
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Logo,Description")] Cinema Cenima)
        {
            if (!ModelState.IsValid)
            {
                return View(Cenima);
            }
            await _services.AddAsync(Cenima);
            return RedirectToAction(nameof(Index));
        }


        // get details
        public async Task<IActionResult> Details(int id)
        {
            var cenaimaDetails = await _services.GetByIdAsync(id);
            if (cenaimaDetails == null) return View("Not Found");
            return View(cenaimaDetails);
        }

        // Edit
        public async Task<IActionResult> Edit(int id)
        {
            var cenaimaDetails = await _services.GetByIdAsync(id);
            if (cenaimaDetails == null) return View("Not Found");
            return View(cenaimaDetails);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _services.UpdateAsync(id, cinema);
            return RedirectToAction(nameof(Index));
        }
        // Delete
        public async Task<IActionResult> Delete(int id)
        {
            var cenaimaDetails = await _services.GetByIdAsync(id);
            if (cenaimaDetails == null) return View("Not Found");
            return View(cenaimaDetails);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteProducer(int id)
        {
            var cinema = await _services.GetByIdAsync(id);
            if (cinema == null) return View("Not Found");
            await _services.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
