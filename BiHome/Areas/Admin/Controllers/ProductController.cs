using BiHome.Areas.Admin.ViewModels;
using BiHome.Models;
using BiHome.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BiHome.Areas.Admin.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly BiHomeContext _context;
        private readonly UserManager<AppUser> _userManager;

        public ProductController(BiHomeContext context, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            VM_Product model = new VM_Product();
            model.Products = _context.Products.ToList();
            return View(model);
        }


        public async Task<IActionResult> Create(VM_Product request)
        {
            var user = await _userManager.FindByIdAsync(User.Identity.Name);

            _context.Products.AddAsync(new Models.Database.Product.Product()
            {
                CREATED_DATE = DateTimeOffset.UtcNow,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                StockQuantity = request.StockQuantity,
                Image = request.Image,
                Discount = request.Discount,
                IS_POPULER = request.IS_POPULER,
                URL = request.URL,
                CategoryId = request.CategoryId,
                BrandId = request.BrandId,
                TypeId = request.TypeId,
                ColorId = request.ColorId,
            });
            _context.SaveChanges();

            return RedirectToAction(nameof(Admin.Controllers.ProductController.Index));
        }
    }
}
