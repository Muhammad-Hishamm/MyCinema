using Microsoft.AspNetCore.Mvc;
using MyCinema.Data;
using MyCinema.Data.Services;

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
    }
}
