using BiHome.Models.Database.Const;
using BiHome.Models.Database.Product;

namespace BiHome.ViewModel
{
    public class VM_Shop
    {
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public List<Color> Colors { get; set; }
        public List<Brand> Brands { get; set; }
        public List<Kind> Kinds { get; set; }

    }
}
