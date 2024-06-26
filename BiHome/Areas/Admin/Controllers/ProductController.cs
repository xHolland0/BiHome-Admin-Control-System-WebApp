﻿using Azure.Core;
using BiHome.Areas.Admin.ViewModels;
using BiHome.Models;
using BiHome.Models.Database.Const;
using BiHome.Models.Database.Product;
using BiHome.Models.Identity;
using BiHome.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using static System.Net.Mime.MediaTypeNames;

namespace BiHome.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly BiHomeContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IFileProvider _fileProvider;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

        public ProductController(BiHomeContext context, UserManager<AppUser> userManager, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment, IFileProvider fileProvider)
        {
            _userManager = userManager;
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            _fileProvider = fileProvider;
        }


        List<SelectListItem> getCategoriesItems()
        {
            List<Category> categories = _context.Categories.ToList();
            List<SelectListItem> selectList = new List<SelectListItem>();

            foreach (Category category in categories)
            {
                SelectListItem item = new SelectListItem();
                item.Text = category.Name;
                item.Value = category.Id.ToString();
                selectList.Add(item);
            }

            return selectList;
        }
        List<SelectListItem> getBrandsItems()
        {
            List<Brand> brands= _context.Brands.ToList();
            List<SelectListItem> selectList = new List<SelectListItem>();

            foreach (Brand brand in brands)
            {
                SelectListItem item = new SelectListItem();
                item.Text = brand.Name;
                item.Value = brand.Id.ToString();
                selectList.Add(item);
            }

            return selectList;
        }
        List<SelectListItem> getColorsItems()
        {
            List<Color> colors = _context.Colors.ToList();
            List<SelectListItem> selectList = new List<SelectListItem>();

            foreach (Color color in colors)
            {
                SelectListItem item = new SelectListItem();
                item.Text = color.Name;
                item.Value = color.Id.ToString();
                selectList.Add(item);
            }

            return selectList;
        }
        List<SelectListItem> getKindsItems()
        {
            List<Kind> kinds = _context.Kinds.ToList();
            List<SelectListItem> selectList = new List<SelectListItem>();

            foreach (Kind kind in kinds)
            {
                SelectListItem item = new SelectListItem();
                item.Text = kind.Name;
                item.Value = kind.Id.ToString();
                selectList.Add(item);
            }

            return selectList;
        }


        public IActionResult Index()
        {
            VM_EditProduct model = new VM_EditProduct();
            model.Products = _context.Products.ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.SelectListCategory = getCategoriesItems();
            ViewBag.SelectListBrand = getBrandsItems();
            ViewBag.SelectListColor = getColorsItems();
            ViewBag.SelectListKind = getKindsItems();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(VM_EditProduct request, List<IFormFile> ProdImages)
        {

                Product product = new Product()
                {
                    Name = request.Name,
                    Description = request.Description,
                    Price = request.Price,
                    StockQuantity = request.StockQuantity,
                    Discount = request.Discount,
                    IS_POPULER = request.IS_POPULER,
                    URL = request.URL,
                    CREATED_DATE = DateTimeOffset.UtcNow,
                    Category = _context.Categories.FirstOrDefault(x => x.Id == request.CategoryId),
                    Brand = _context.Brands.FirstOrDefault(x => x.Id == request.BrandId),
                    Color = _context.Colors.FirstOrDefault(x => x.Id == request.ColorId),
                    Kind = _context.Kinds.FirstOrDefault(x => x.Id == request.KindId)
                };


            if (request.Image != null && request.Image.Length > 0)
            {
                var wwwrootFolder = _fileProvider.GetDirectoryContents("wwwroot");
                string randomFileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(request.Image.FileName)}";
                string userpicturesPath = wwwrootFolder.First(x => x.Name == "Image").PhysicalPath + "\\ProductImages";
                var filePath = Path.Combine(userpicturesPath, randomFileName);


                using var stream = new FileStream(filePath, FileMode.Create);
                await request.Image.CopyToAsync(stream);

                product.Image = randomFileName;
            }
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Admin.Controllers.ProductController.Index));

            ViewBag.SelectListCategory = getCategoriesItems();
            ViewBag.SelectListBrand = getBrandsItems();
            ViewBag.SelectListColor = getColorsItems();
            ViewBag.SelectListKind = getKindsItems();
            return View();
        }


        public async Task<IActionResult> Delete(int id)
        {
            var products = _context.Products.FirstOrDefault(x=>x.Id == id);
            _context.Products.Remove(products);
            _context.SaveChanges();

            return RedirectToAction(nameof(Admin.Controllers.ProductController.Index));
        }


        [HttpGet]
        public async Task<IActionResult> Update(VM_EditProduct request,int id)
        {
            Product newProduct = _context.Products.Include(x=>x.Category).Include(x => x.Kind).Include(x => x.Color).Include(x => x.Brand).FirstOrDefault(x=>x.Id == id);
              
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(request.Image.FileName);


			Product product = new Product()
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Discount = request.Discount,
                IS_POPULER = bool.Parse(request.IS_POPULER.ToString()),
                StockQuantity = request.StockQuantity,
                URL = request.URL,
                CREATED_DATE = DateTimeOffset.UtcNow,
                CategoryId = request.CategoryId,
                KindId = request.KindId,
                BrandId = request.BrandId,
                ColorId = request.ColorId,
                Image = fileName
            };

            return View(product);
        }



        [HttpPost]
        public async Task<IActionResult> Update(VM_EditProduct request)
        {
            request.CategorySelectList = getCategoriesItems();
            request.ColorSelectList = getColorsItems();
            request.KindSelectList = getKindsItems();
            request.BrandSelectList = getBrandsItems();


            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(request.Image.FileName);
            if (request.Image != null)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "product", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await request.Image.CopyToAsync(stream);
                }
            }

            Product product = new Product()
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Discount = request.Discount,
                IS_POPULER = bool.Parse(request.IS_POPULER.ToString()),
                StockQuantity = request.StockQuantity,
                URL = request.URL,
                CREATED_DATE = DateTimeOffset.UtcNow,
                Category = _context.Categories.FirstOrDefault(x=>x.Id == request.CategoryId),
                Brand = _context.Brands.FirstOrDefault(x => x.Id == request.BrandId),
                Kind = _context.Kinds.FirstOrDefault(x => x.Id == request.KindId),
                Color = _context.Colors.FirstOrDefault(x => x.Id == request.ColorId),
                Image = fileName
            };

            if (ModelState.IsValid)
            {
                _context.Products.Update(product);
                _context.SaveChanges();

                return RedirectToAction("Index", _context.Products.ToList());
            }
            return View(request);
        }

    }
}
