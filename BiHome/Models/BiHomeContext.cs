using BiHome.Models.Database.Product;
using BiHome.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Bson;

namespace BiHome.Models
{
    public class BiHomeContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public BiHomeContext(DbContextOptions<BiHomeContext> options) : base(options) { }

        //!---------------------| CONST |---------------------
        public DbSet <Brand> Brands{ get; set; }
        public DbSet <Category> Categories { get; set; }
        public DbSet <Color> Colors { get; set; }
        public DbSet <Supplier> Suppliers { get; set; }
        public DbSet <Genre> Genres { get; set; }

        //!---------------------| PRODUCT |---------------------
        public DbSet<Product> Products { get; set; }

    }
}
