using Microsoft.AspNetCore.Mvc;
using ASP_WS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASP_WS.Controllers
{
    public class BreedController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        AppDbContext _appDbContext;

        public BreedController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _appDbContext = context;
        }

        public IActionResult Page(int id)
        {
            return View(_appDbContext.Breeds.First(u => u.Id == id));
        }
        #region Breed
        public IActionResult CreateBreed()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBreed(Breed breed)
        {
            _appDbContext.Breeds.Add(breed);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Edit(int id)
        {
            Breed breed = _appDbContext.Breeds.First(u => u.Id == id);
            return View(breed);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Breed breed, int id)
        {
            Breed oldBreed = _appDbContext.Breeds.First(u => u.Id == id);
            oldBreed.Description = breed.Description;
            oldBreed.Name = breed.Name;
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }


        #endregion


    }
}
