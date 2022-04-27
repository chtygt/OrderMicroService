using System.Net;
using Microsoft.EntityFrameworkCore;
using Services.Order.Model;
using Services.Order.Repositories.Interfaces;
using Services.Shared.Models;

namespace Services.Order.Api.Services
{
    public class OrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemService(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public ApiResult Get(Guid id)
        {
            var orderItem = _orderItemRepository.FirstOrDefault(x => x.Id == id);
            if (orderItem == null)
                return new ApiResult(HttpStatusCode.NotFound, "Sipariş detayı bulunamadı.");

            return new ApiResult(HttpStatusCode.OK, orderItem);
        }


        public ApiResult Add(OrderItem orderItem)
        {
            var result = _orderItemRepository.Add(orderItem).SaveChanges();
            if (!result)
                return new ApiResult(HttpStatusCode.BadRequest, "Bir sorun oluştu. Lütfen tekrar deneyiniz.");

            return new ApiResult(HttpStatusCode.OK, "Sipariş detayı eklendi.");
        }

        public ApiResult Update(OrderItem orderItem)
        {
            var isExist = _orderItemRepository.Any(x => x.Id == orderItem.Id);
            if (!isExist)
                return new ApiResult(HttpStatusCode.NotFound, "Sipariş detayı bulunamadı");

            bool result;
            try
            {
                result = _orderItemRepository.Update(orderItem).SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                return new ApiResult(HttpStatusCode.BadRequest, e.Message);
            }

            if (!result)
                return new ApiResult(HttpStatusCode.BadRequest, "Bir sorun oluştu. Lütfen tekrar deneyiniz.");

            return new ApiResult(HttpStatusCode.OK, "Sipariş deatayı güncellendi.");
        }

        public ApiResult Delete(Guid id)
        {
            var isExist = _orderItemRepository.Any(x => x.Id == id);
            if (!isExist)
                return new ApiResult(HttpStatusCode.NotFound, "Sipariş detayı bulunamadı.");

            var result = _orderItemRepository.Delete(id).SaveChanges();
            if (!result)
                return new ApiResult(HttpStatusCode.BadRequest, "Bir sorun oluştu. Lütfen tekrar deneyiniz.");

            return new ApiResult(HttpStatusCode.OK, "Sipariş detayı silindi.");

        }

        public ApiResult List(Guid orderItemId, int offset, int limit)
        {
            var list = _orderItemRepository.GetAllAsNoTracking(x => x.Id == orderItemId, offset, limit).AsEnumerable();
            if (!list.Any())
                return new ApiResult(HttpStatusCode.NotFound, "Sipariş detayı bulunamadı.");

            var totalCount = _orderItemRepository.Count();
            return new ApiResult(HttpStatusCode.OK, list, "", totalCount);
        }
        public ApiResult ListAll()
        {
            var list = _orderItemRepository.GetAllAsNoTracking().AsEnumerable();
            if (!list.Any())
                return new ApiResult(HttpStatusCode.NotFound, "Sipariş detayı bulunamadı.");

            var totalCount = _orderItemRepository.Count();
            return new ApiResult(HttpStatusCode.OK, list, "", totalCount);
        }
        public ApiResult Count(Guid orderItemId)
        {
            var totalCount = _orderItemRepository.Count(x => x.Id == orderItemId);
            return new ApiResult(HttpStatusCode.OK, totalCount);
        }
    }
}
