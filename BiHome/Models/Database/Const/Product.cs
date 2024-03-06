using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BiHome.Models.Database.Product
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }
        public string? Image { get; set; }



        public DateTimeOffset? CREATED_DATE { get; set; }
        public short? Discount { get; set; }
        public bool? IS_POPULER { get; set; }
        public string? URL { get; set; }


        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int TypeId { get; set; }
        public int ColorId { get; set; }


        //=========> REFERANCES
        public virtual Category Category { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual Type Type{ get; set; }

        public virtual Color Color { get; set; }

        public virtual List<Supplier> Suppliers { get; set; }
    }
}
