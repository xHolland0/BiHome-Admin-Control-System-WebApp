using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BiHome.Models.Database.Product
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        //[AllowNull]
        //public string Image { get; set; } = null!;
    }
}
