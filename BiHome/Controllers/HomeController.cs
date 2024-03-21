using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Drawing.Text;
using BiHome.Models.Identity;
using BiHome.Models;
using BiHome.ViewModel.Auth;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using BiHome.Extensions;


namespace BiHome.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly BiHomeContext _biHomeContext;



        public HomeController(ILogger<HomeController> logger,UserManager<AppUser> userManager ,SignInManager<AppUser> signInManager, BiHomeContext biHomeContext)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _biHomeContext = biHomeContext; 
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(VM_SignUp request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var usernameIsExist = await _userManager.FindByNameAsync(request.Username);
            if (usernameIsExist != null)
            {
                TempData["ExistUserName"] = $"'{request.Username}' daha önce baþka bir kullanýcý tarafýndan alýnmýþtýr.";
                return RedirectToAction(nameof(HomeController.SignUp));
            }

            var identityResult = await _userManager.CreateAsync(new()
                {
                UserName = request.Username,
                Email = request.Email,  
                PhoneNumber =request.Phone,
                }
                ,request.PasswordConfirm);

            if (!identityResult.Succeeded)
            {
                ModelState.AddModelErrorList(identityResult.Errors.Select(x => x.Description).ToList());
                return View();
            }


            TempData["SucccessMessage"] = "Üyelik iþlemi baþarýlý bir þekilde gerçekleþmiþtir.";
            return RedirectToAction(nameof(HomeController.SignUp));
        }


        public IActionResult SignIn()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(VM_SignIn request, string? returnurl = null)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            returnurl = returnurl ?? Url.Action("Index", "Home");

            var hasUser = await _userManager.FindByEmailAsync(request.Email);

            if (hasUser == null)
            {
                ModelState.AddModelError(string.Empty, "Email veya þifre hatalý.");
                return View();
            }

            var signInResult = await _signInManager.PasswordSignInAsync(hasUser, request.Password, request.RememberMe, true);

            if (signInResult.Succeeded)
            {
                return Redirect(returnurl!);
            }

            if (signInResult.IsLockedOut)
            {
                var userLockoutEndTime = await _userManager.GetLockoutEndDateAsync(hasUser);
                double userLockoutTemainTimeSec = (userLockoutEndTime.GetValueOrDefault().LocalDateTime - DateTime.Now).TotalSeconds;
                ModelState.AddModelErrorList(new List<string>() { $"Çok fazla yanlýþ deneme yaptýnýz, { TimeSpan.FromSeconds(userLockoutTemainTimeSec).ToString(@"m\:ss")}dakika sonra tekrar deneyiniz."});
                return View();
            }

            ModelState.AddModelErrorList(new List<string> { $"Email veya þifre hatalý." });

            return View();
        }








        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
