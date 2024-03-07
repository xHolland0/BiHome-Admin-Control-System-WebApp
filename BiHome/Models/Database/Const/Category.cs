using System.ComponentModel.DataAnnotations;

namespace BiHome.Models.Database.Product
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
