using Microsoft.AspNetCore.Mvc;
using MyCinema.Data;
using MyCinema.Data.Services;
using MyCinema.Models;

namespace MyCinema.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorServices _services;
        public ActorsController(IActorServices  services)
        {
            _services = services;
        }
        public async Task<IActionResult> Index()
        {
            var ActorsList =await _services.GetAllActors();
            return View(ActorsList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create ([Bind("FullName,ProfilePictureURL,Bio")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            _services.Add(actor);
            return RedirectToAction(nameof(Index));

        }
    }
}
