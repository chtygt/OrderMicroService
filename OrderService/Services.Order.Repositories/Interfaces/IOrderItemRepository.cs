using Services.Order.Model;
using Services.Shared.Data.Repository;

namespace Services.Order.Repositories.Interfaces
{
    public interface IOrderItemRepository: IRepository<OrderItem>
    {
    }
}
