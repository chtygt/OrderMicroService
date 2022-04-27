using Microsoft.EntityFrameworkCore;
using Services.Customer.Model;

namespace Services.Customer.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
            : base(options)
        {

        }

        public DbSet<Model.Customer> Customers { get; set; }
    }
}
