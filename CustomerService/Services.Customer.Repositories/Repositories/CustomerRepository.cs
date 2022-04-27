using Services.Customer.Data;
using Services.Shared.Data.Repository;
using Services.Customer.Repositories.Interfaces;

namespace Services.Customer.Repositories.Repositories
{
    public class CustomerRepository : Repository<Model.Customer>, ICustomerRepository
    {
        public CustomerRepository(CustomerDbContext context) : base(context)
        {

        }
    }
}
