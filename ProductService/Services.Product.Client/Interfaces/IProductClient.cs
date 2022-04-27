using Services.Shared.Models;

namespace Services.Product.Client.Interfaces;

public interface IProductClient
{
    ServiceResult<Model.Product> Get(Guid productId);
    ServiceResult Add(Model.Product product);
    ServiceResult Update(Model.Product product);
    ServiceResult Delete(Guid productId);
    ServiceResult<List<Model.Product>> List(int offset = 0, int limit = 1000);
    ServiceResult Count();
}