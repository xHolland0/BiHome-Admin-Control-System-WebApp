using System.ComponentModel.DataAnnotations;

namespace BiHome.Models.Database.Product
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Image { get; set; } = null!;
    }
}
