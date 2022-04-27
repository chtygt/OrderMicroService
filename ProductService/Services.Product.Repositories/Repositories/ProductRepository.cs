using Services.Product.Data;
using Services.Shared.Data.Repository;
using Services.Product.Repositories.Interfaces;

namespace Services.Product.Repositories.Repositories
{
    public class ProductRepository : Repository<Model.Product>, IProductRepository
    {
        public ProductRepository(ProductDbContext context) : base(context)
        {

        }
    }
}
