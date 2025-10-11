using Microsoft.AspNetCore.Mvc;
using MyCinema.Data;
using MyCinema.Models;
using MyCinema.Data.Services.Actors;
using MyCinema.Data.Services.Actors;

namespace MyCinema.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorServices _services;
        public ActorsController(IActorServices services)
        {
            _services = services;
        }

        public async Task<IActionResult> Index()
        {
            var ActorsList =await _services.GetAllAsync();
            return View(ActorsList);
        }   

        // create new actor
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _services.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }


        // get details
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails =await  _services.GetByIdAsync(id);
            if (actorDetails == null) return View("Not Found");
            return View (actorDetails);
        }

        // Edit
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _services.GetByIdAsync(id);
            if (actorDetails == null) return View("Not Found");
            return View(actorDetails);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _services.UpdateAsync(id, actor);
            return RedirectToAction(nameof(Index));
        }
        // Delete
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _services.GetByIdAsync(id);
            if (actorDetails == null) return View("Not Found");
            return View(actorDetails);
        }


        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteActor(int id)
        {
            var actor =await _services.GetByIdAsync(id);
            if (actor == null) return View("Not Found");
            await _services.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
