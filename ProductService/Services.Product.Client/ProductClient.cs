using Services.Shared.Client;
using Microsoft.Extensions.Options;
using RestSharp;
using Services.Product.Client.Base;
using Services.Product.Client.Interfaces;
using Services.Shared.Authentication.Helper;
using Services.Shared.Models;

namespace Services.Product.Client
{
    public class ProductClient : ClientBase, IProductClient
    {
        public ProductClient(HttpContextHelper httpContext, IOptions<ProductServiceClientOptions> options)
              : base(httpContext.LoggedUser.AccessToken, options.Value)
        {
        }

        public ServiceResult Add(Model.Product model)
        {
            var request = CreateRequest<ServiceResult>(ProductApiConstants.ProductAdd, model, Method.Post);
            return HandleResponse(request);
        }

        public ServiceResult<Model.Product> Get(Guid productId)
        {
            var request = CreateRequest<ServiceResult<Model.Product>>(ProductApiConstants.ProductGet, null, Method.Get,
                new UrlSegmentParam() { Name = "id", Value = productId });
            return HandleResponse(request);
        }
        public ServiceResult Update(Model.Product model)
        {
            var request = CreateRequest<ServiceResult>(ProductApiConstants.ProductUpdate, model, Method.Post);
            return HandleResponse(request);
        }

        public ServiceResult Delete(Guid productId)
        {
            var request = CreateRequest<ServiceResult>(ProductApiConstants.ProductDelete, null, Method.Delete,
                new UrlSegmentParam() { Name = "id", Value = productId });
            return HandleResponse(request);
        }

        public ServiceResult<List<Model.Product>> List(int offset = 0, int limit = 1000)
        {
            var request = CreateRequest<ServiceResult<List<Model.Product>>>(ProductApiConstants.ProductList, null, Method.Get,
                new UrlSegmentParam() { Name = "offset", Value = offset },
                new UrlSegmentParam() { Name = "limit", Value = limit });
            return HandleResponse(request);
        }



        public ServiceResult Count()
        {
            var request = CreateRequest<ServiceResult>(ProductApiConstants.ProductCount, null, Method.Get);
            return HandleResponse(request);
        }
    }
}
