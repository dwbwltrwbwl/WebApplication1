using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Category> categories { get; set; }
        public DbSet<Country_Manufacturer> country_Manufacturers { get; set; }
        public DbSet<Firm> firms { get; set; }
        public DbSet<Material> materials { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Supplier> suppliers { get; set; }
        public DbSet<User> users { get; set; }
        
    }
}
