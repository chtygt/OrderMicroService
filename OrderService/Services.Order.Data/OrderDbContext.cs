using Microsoft.EntityFrameworkCore;
using Services.Order.Model;

namespace Services.Order.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options)
            : base(options)
        {

        }

        public DbSet<Model.Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
