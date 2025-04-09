using Microsoft.EntityFrameworkCore;

namespace Catgeory_Ef.Models
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):
            base(options)
        {
            
        }

        public DbSet<Category> categories { get; set; }
        public DbSet<Product>products { get; set; }
        public DbSet <SubCategory> subcategories { get; set; }
    }
}
