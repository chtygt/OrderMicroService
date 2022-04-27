using Services.Shared.Models;

namespace Services.Order.Client.Interfaces;

public interface IOrderClient
{
    ServiceResult<Model.Order> Get(Guid orderId);
    ServiceResult Add(Model.Order Order);
    ServiceResult Update(Model.Order Order);
    ServiceResult Delete(Guid orderId);
    ServiceResult<List<Model.Order>> List(int offset = 0, int limit = 1000);

    ServiceResult<List<Model.Order>> ListByDate(DateTime startDate, DateTime endDate, bool orderStatus, int offset = 0, int limit = 1000);
    ServiceResult Count();
}