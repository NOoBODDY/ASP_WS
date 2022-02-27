using Microsoft.AspNetCore.Mvc;
using ASP_WS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASP_WS.Controllers
{
    public class DogController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        AppDbContext _appDbContext;
        IWebHostEnvironment _appEnvironment;

        public DogController(ILogger<HomeController> logger, AppDbContext context, IWebHostEnvironment appEnvironment)
        {
            _logger = logger;
            _appDbContext = context;
            _appEnvironment = appEnvironment;
        }

        #region Dog

        public IActionResult CreateDog()
        {
            var Owners = _appDbContext.Owners.ToList();
            var Breeds = _appDbContext.Breeds.ToList();
            ViewBag.Owners = new SelectList(Owners, "Id", "Name");
            ViewBag.Breeds = new SelectList(Breeds, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateDog(string Name, int BreedId, int OwnerId, DateTime Birthday, IFormFile uploadedfile)
        {
            if (uploadedfile != null)
            {
                // путь к папке Files
                string path = "/Files/" + uploadedfile.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedfile.CopyToAsync(fileStream);
                }
                Dog Dog = new Dog { Name = Name, BreedId = BreedId, OwnerId = OwnerId, Birthday = Birthday, AvatarPath = path };
                _appDbContext.Dogs.Add(Dog);
                await _appDbContext.SaveChangesAsync();
                
            }
            return RedirectToAction("Index", "Home");

        }

        public async Task<IActionResult> Delete(int id)
        {
            _appDbContext.Dogs.Remove(_appDbContext.Dogs.First(u => u.Id == id));
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        #endregion

        public IActionResult Page(int id)
        {
            return View(_appDbContext.Dogs.Include(u => u.Owner).Include(u=> u.Breed).First(u => u.Id == id));
        }
    }
}
