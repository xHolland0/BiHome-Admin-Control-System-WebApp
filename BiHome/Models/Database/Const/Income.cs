using Microsoft.CodeAnalysis.Options;
using System.ComponentModel.DataAnnotations;

namespace BiHome.Models.Database.Product
{
    public class Income
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public int ProductId { get; set; }
        public int SELLED_USER_ID { get; set; }
        public DateTimeOffset? SELLED_DATE { get; set; } = DateTimeOffset.UtcNow;
        public int Quantity { get; set; }


        public virtual Product Product { get; set; }
    }
}
