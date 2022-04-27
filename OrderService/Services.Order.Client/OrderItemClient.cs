using Microsoft.Extensions.Options;
using RestSharp;
using Services.Order.Client.Base;
using Services.Order.Client.Interfaces;
using Services.Order.Model;
using Services.Shared.Authentication.Helper;
using Services.Shared.Client;
using Services.Shared.Models;

namespace Services.Order.Client
{
    public class OrderItemClient : ClientBase, IOrderItemClient
    {
        public OrderItemClient(HttpContextHelper httpContext, IOptions<OrderServiceClientOptions> options)
            : base(httpContext.LoggedUser.AccessToken, options.Value)
        {
        }
        public ServiceResult Add(OrderItem model)
        {
            var request = CreateRequest<ServiceResult>(OrderApiConstants.OrderItemAdd, model, Method.Post);
            return HandleResponse(request);
        }

        public ServiceResult<OrderItem> Get(Guid orderItemId)
        {
            var request = CreateRequest<ServiceResult<OrderItem>>(OrderApiConstants.OrderItemGet, null, Method.Get,
                new UrlSegmentParam() { Name = "id", Value = orderItemId });
            return HandleResponse(request);
        }

        public ServiceResult Update(OrderItem model)
        {
            var request = CreateRequest<ServiceResult>(OrderApiConstants.OrderItemUpdate, model, Method.Post);
            return HandleResponse(request);
        }

        public ServiceResult Delete(Guid orderItemId)
        {
            var request = CreateRequest<ServiceResult>(OrderApiConstants.OrderItemDelete, null, Method.Delete,
                new UrlSegmentParam() { Name = "id", Value = orderItemId });
            return HandleResponse(request);
        }

        public ServiceResult<List<OrderItem>> List(Guid orderId, int offset = 0, int limit = 1000)
        {
            var request = CreateRequest<ServiceResult<List<OrderItem>>>(OrderApiConstants.OrderItemList, null, Method.Get,
                new UrlSegmentParam() { Name = "orderId", Value = orderId },
                new UrlSegmentParam() { Name = "offset", Value = offset },
                new UrlSegmentParam() { Name = "limit", Value = limit });
            return HandleResponse(request);
        }

        public ServiceResult<List<OrderItem>> ListAll()
        {
            var request = CreateRequestAnonymous<ServiceResult<List<OrderItem>>>(OrderApiConstants.OrderItemListAll, null, Method.Get);
            return HandleResponse(request);
        }

        public ServiceResult Count(Guid orderId)
        {
            var request = CreateRequest<ServiceResult>(OrderApiConstants.OrderItemCount, null, Method.Get, new UrlSegmentParam() { Name = "orderId", Value = orderId });
            return HandleResponse(request);
        }
    }
}
