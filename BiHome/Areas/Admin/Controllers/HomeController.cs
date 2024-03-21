using BiHome.Models;
using BiHome.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BiHome.Areas.Admin.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly BiHomeContext _context;
        private readonly UserManager<AppUser> _userManager;


        public HomeController(BiHomeContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
