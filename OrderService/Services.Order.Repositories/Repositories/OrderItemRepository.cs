using Services.Order.Data;
using Services.Order.Model;
using Services.Order.Repositories.Interfaces;
using Services.Shared.Data.Repository;

namespace Services.Order.Repositories.Repositories
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(OrderDbContext context) : base(context)
        {

        }
    }
}
