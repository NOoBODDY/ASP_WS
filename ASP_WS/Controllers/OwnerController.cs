using Microsoft.AspNetCore.Mvc;
using ASP_WS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASP_WS.Controllers
{
    public class OwnerController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        AppDbContext _appDbContext;

        public OwnerController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _appDbContext = context;
        }

        #region Owner

        public IActionResult CreateOwner()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOwner(Owner owner)
        {
            _appDbContext.Owners.Add(owner);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        #endregion



        public IActionResult Page(int id)
        {
            
            return View(_appDbContext.Owners.Include(u => u.Dogs).First(u => u.Id == id));
        }
    }
}
