using Services.Order.Model;
using Services.Shared.Models;

namespace Services.Order.Client.Interfaces;

public interface IOrderItemClient
{
    ServiceResult<OrderItem> Get(Guid orderItemId);
    ServiceResult Add(OrderItem orderItem);
    ServiceResult Update(OrderItem orderItem);
    ServiceResult Delete(Guid orderItem);
    ServiceResult<List<OrderItem>> List(Guid orderId, int offset = 0, int limit = 1000);
    ServiceResult<List<OrderItem>> ListAll();
    ServiceResult Count(Guid orderItem);
}