using BiHome.Models;
using BiHome.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace BiHome.Controllers
{
	public class UserController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;
		private readonly UserManager<AppUser> _userManager;
		private readonly IFileProvider _fileProvider;
		private readonly BiHomeContext _context;

		public UserController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IFileProvider fileProvider, BiHomeContext context)
		{
			_signInManager = signInManager;
			_userManager = userManager;
			_fileProvider = fileProvider;
			_context = context;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> LogOut(string returnurl)
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}
	}
}
