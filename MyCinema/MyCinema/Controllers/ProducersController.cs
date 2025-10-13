using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCinema.Data;
using MyCinema.Data.Services.Producers;
using MyCinema.Models;

namespace MyCinema.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducerServices _services;
        public ProducersController(IProducerServices services)
        {
            _services = services;
        }

        public async Task<IActionResult> Index()
        {
            var ProducersList = await _services.GetAllAsync();
            return View(ProducersList);
        }

        // create new producer
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _services.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }

        // get details
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _services.GetByIdAsync(id);
            if (producerDetails == null) return View("Not Found");
            return View(producerDetails);
        }

        // Edit
        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await _services.GetByIdAsync(id);
            if (producerDetails == null) return View("Not Found");
            return View(producerDetails);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _services.UpdateAsync(id, producer);
            return RedirectToAction(nameof(Index));
        }
        // Delete
        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails = await _services.GetByIdAsync(id);
            if (producerDetails == null) return View("Not Found");
            return View(producerDetails);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteProducer(int id)
        {
            var producer = await _services.GetByIdAsync(id);
            if (producer == null) return View("Not Found");
            await _services.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
