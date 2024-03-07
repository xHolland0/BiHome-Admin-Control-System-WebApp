using System.ComponentModel.DataAnnotations;

namespace BiHome.Models.Database.Product
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }

        public string CompanyName { get; set; } = null!;


        public string ContactName { get; set; } = null!;


        public string PhoneNumber { get; set; } = null!;


        public string Email { get; set; } = null!;


        public string Adress { get; set; } = null!;


        public int ProductId { get; set; }


        //=========> REFERANCES

        public virtual Product Product { get; set; }
    }
}
