using System.ComponentModel.DataAnnotations;

namespace BiHome.Models.Database.Product
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Image { get; set; } = null!;
    }
}
