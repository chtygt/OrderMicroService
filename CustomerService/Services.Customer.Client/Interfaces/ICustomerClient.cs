using Services.Shared.Models;

namespace Services.Customer.Client.Interfaces;

public interface ICustomerClient
{
    ServiceResult<Model.Customer> Get(Guid customerId);
    ServiceResult Add(Model.Customer customer);
    ServiceResult Update(Model.Customer customer);
    ServiceResult Delete(Guid customerId);
    ServiceResult<List<Model.Customer>> List(int offset = 0, int limit = 1000);
    ServiceResult Count();
}