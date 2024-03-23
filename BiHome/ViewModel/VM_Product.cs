using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BiHome.ViewModel
{
    public class VM_Product
    {
        public int Id { get; set; }

        [DisplayName("Ürün Ad")]
        [Required(ErrorMessage = "Ürün Ad alanı boş bırakılamaz.")]
        [MaxLength(128,ErrorMessage ="Ürün adı en fazla 128 karakter olabilir.")]
        public string Name { get; set; } = null!;

        [DisplayName("Açıklama")]
        [Required(ErrorMessage = "Açıklama alanı boş bırakılamaz.")]
        [MaxLength(512, ErrorMessage ="Açıklama kısmı en fazla 512 karakter olabilir.")]
        public string? Description { get; set; }

        [DisplayName("Fiyat")]
        [Required(ErrorMessage = "Fiyat alanı boş bırakılamaz.")]
        public decimal Price { get; set; }

        [DisplayName("StokSayısı")]
        [Required(ErrorMessage = "Stok Sayısı alanı boş bırakılamaz.")]
        public int StockQuantity { get; set; }

        [DisplayName("Resim")]
        [Required(ErrorMessage = "Resim alanı boş bırakılamaz.")]
        public IFormFile Image { get; set; }





        public DateTimeOffset? CREATED_DATE { get; set; }
        public short? Discount { get; set; }
        public bool? IS_POPULER { get; set; }
        public string? URL { get; set; }


        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int TypeId { get; set; }
        public int ColorId { get; set; }


        public List<SelectListItem> CategorySelectList { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> BrandSelectList { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> TypeSelectList { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> ColorSelectList { get; set; } = new List<SelectListItem>();
    }
}
