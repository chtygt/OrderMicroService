using Microsoft.EntityFrameworkCore;
using Services.Product.Model;

namespace Services.Product.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        {

        }

        public DbSet<Model.Product> Products { get; set; }
    }
}
