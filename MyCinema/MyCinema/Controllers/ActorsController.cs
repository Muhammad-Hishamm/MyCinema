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
            var ActorsList =await _services.GetAllActorsAsync();
            return View(ActorsList);
        }


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



        public async Task<IActionResult> Details(int id)
        {
            var actorDetails =await  _services.GetActorByIdAsync(id);
            if (actorDetails == null) return View("Not Found");
            return View (actorDetails);
        }


        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _services.GetActorByIdAsync(id);
            if (actorDetails == null) return View("Not Found");
            return View(actorDetails);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _services.UpdateAsync(id,actor);
            return RedirectToAction(nameof(Index));
        }
    }
}
