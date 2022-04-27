using Services.Order.Data;
using Services.Shared.Data.Repository;
using Services.Order.Repositories.Interfaces;

namespace Services.Order.Repositories.Repositories
{
    public class OrderRepository : Repository<Model.Order>, IOrderRepository
    {
        public OrderRepository(OrderDbContext context) : base(context)
        {

        }
    }
}
