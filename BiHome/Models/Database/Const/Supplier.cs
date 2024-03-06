using System.ComponentModel.DataAnnotations;

namespace BiHome.Models.Database.Product
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string CompanyName { get; set; } = null!;

        [Required]
        public string ContactName { get; set; } = null!;

        [Required]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string Adress { get; set; } = null!;


        public int ProductId { get; set; }


        //=========> REFERANCES

        public virtual Product Product { get; set; }
    }
}
