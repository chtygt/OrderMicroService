using Services.Shared.Client;
using Microsoft.Extensions.Options;
using RestSharp;
using Services.Order.Client.Base;
using Services.Order.Client.Interfaces;
using Services.Shared.Authentication.Helper;
using Services.Shared.Models;

namespace Services.Order.Client
{
    public class OrderClient : ClientBase, IOrderClient
    {
        public OrderClient(HttpContextHelper httpContext, IOptions<OrderServiceClientOptions> options)
              : base(httpContext.LoggedUser.AccessToken, options.Value)
        {
        }

        public ServiceResult Add(Model.Order model)
        {
            var request = CreateRequest<ServiceResult>(OrderApiConstants.OrderAdd, model, Method.Post);
            return HandleResponse(request);
        }

        public ServiceResult<Model.Order> Get(Guid contactId)
        {
            var request = CreateRequest<ServiceResult<Model.Order>>(OrderApiConstants.OrderGet, null, Method.Get,
                new UrlSegmentParam() { Name = "id", Value = contactId });
            return HandleResponse(request);
        }
        public ServiceResult Update(Model.Order model)
        {
            var request = CreateRequest<ServiceResult>(OrderApiConstants.OrderUpdate, model, Method.Post);
            return HandleResponse(request);
        }

        public ServiceResult Delete(Guid contactId)
        {
            var request = CreateRequest<ServiceResult>(OrderApiConstants.OrderDelete, null, Method.Delete,
                new UrlSegmentParam() { Name = "id", Value = contactId });
            return HandleResponse(request);
        }

        public ServiceResult<List<Model.Order>> List(int offset = 0, int limit = 1000)
        {
            var request = CreateRequest<ServiceResult<List<Model.Order>>>(OrderApiConstants.OrderList, null, Method.Get,
                new UrlSegmentParam() { Name = "offset", Value = offset },
                new UrlSegmentParam() { Name = "limit", Value = limit });
            return HandleResponse(request);
        }

        public ServiceResult<List<Model.Order>> ListByDate(DateTime startDate, DateTime endDate,bool orderStatus, int offset = 0, int limit = 1000)
        {
            var request = CreateRequest<ServiceResult<List<Model.Order>>>(OrderApiConstants.OrderList, null, Method.Get,
                new UrlSegmentParam() { Name = "offset", Value = offset },
                new UrlSegmentParam() { Name = "limit", Value = limit });
            return HandleResponse(request);
        }

        public ServiceResult Count()
        {
            var request = CreateRequest<ServiceResult>(OrderApiConstants.OrderCount, null, Method.Get);
            return HandleResponse(request);
        }
    }
}
