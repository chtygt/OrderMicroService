using System.Net;
using Microsoft.EntityFrameworkCore;
using Services.Product.Repositories.Interfaces;
using Services.Shared.Models;

namespace Services.Product.Api.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ApiResult Get(Guid id)
        {
            var product = _productRepository.FirstOrDefault(x => x.Id == id);
            if (product == null)
                return new ApiResult(HttpStatusCode.NotFound, "Ürün bulunamadı.");

            return new ApiResult(HttpStatusCode.OK, product);
        }


        public ApiResult Add(Model.Product product)
        {
            var result = _productRepository.Add(product).SaveChanges();
            if (!result)
                return new ApiResult(HttpStatusCode.BadRequest, "Bilinmeyen bir hata oluştu. Lütfen tekrar deneyiniz.");

            return new ApiResult(HttpStatusCode.OK, "Ürün eklendi.");
        }

        public ApiResult Update(Model.Product product)
        {
            var isExist = _productRepository.Any(x => x.Id == product.Id);
            if (!isExist)
                return new ApiResult(HttpStatusCode.NotFound, "Ürün bulunamadı");

            bool result;
            try
            {
                result = _productRepository.Update(product).SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                return new ApiResult(HttpStatusCode.BadRequest, e.Message);
            }
            if (!result)
                return new ApiResult(HttpStatusCode.BadRequest, "Bilinmeyen bir hata oluştu. Lütfen tekrar deneyiniz.");

            return new ApiResult(HttpStatusCode.OK, "Ürün güncellendi.");
        }

        public ApiResult Delete(Guid id)
        {
            var isExist = _productRepository.Any(x => x.Id == id);
            if (!isExist)
                return new ApiResult(HttpStatusCode.NotFound, "Ürün bulunamadı.");

            var result = _productRepository.Delete(id).SaveChanges();
            if (!result)
                return new ApiResult(HttpStatusCode.BadRequest, "Bilinmeyen bir hata oluştu. Lütfen tekrar deneyiniz.");

            return new ApiResult(HttpStatusCode.OK, "Ürün silindi.");

        }

        public ApiResult List(int offset, int limit)
        {
            var list = _productRepository.GetAllAsNoTracking(offset, limit);
            if (!list.Any())
                return new ApiResult(HttpStatusCode.NotFound, "Ürün bulunamadı.");

            var totalCount = _productRepository.Count();
            return new ApiResult(HttpStatusCode.OK, list, "", totalCount);
        }

        public ApiResult Count()
        {
            var totalCount = _productRepository.Count();
            return new ApiResult(HttpStatusCode.OK, totalCount);
        }
    }
}
