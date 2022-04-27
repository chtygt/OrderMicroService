using System.Net;
using Microsoft.EntityFrameworkCore;
using Services.Order.Repositories.Interfaces;
using Services.Shared.Models;

namespace Services.Order.Api.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public ApiResult Get(Guid id)
        {
            var order = _orderRepository.FirstOrDefault(x => x.Id == id);
            if (order == null)
                return new ApiResult(HttpStatusCode.NotFound, "Sipariş bulunamadı.");

            return new ApiResult(HttpStatusCode.OK, order);
        }


        public ApiResult Add(Model.Order order)
        {
            var result = _orderRepository.Add(order).SaveChanges();
            if (!result)
                return new ApiResult(HttpStatusCode.BadRequest, "Bir sorun oluştu. Lütfen tekrar deneyiniz.");

            return new ApiResult(HttpStatusCode.OK, "Sipariş eklendi.");
        }

        public ApiResult Update(Model.Order order)
        {
            var isExist = _orderRepository.Any(x => x.Id == order.Id);
            if (!isExist)
                return new ApiResult(HttpStatusCode.NotFound, "Sipariş bulunamadı");

            bool result;
            try
            {
                result = _orderRepository.Update(order).SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                return new ApiResult(HttpStatusCode.BadRequest, e.Message);
            }
            if (!result)
                return new ApiResult(HttpStatusCode.BadRequest, "Bir sorun oluştu. Lütfen tekrar deneyiniz.");

            return new ApiResult(HttpStatusCode.OK, "Sipariş güncellendi.");
        }

        public ApiResult Delete(Guid id)
        {
            var isExist = _orderRepository.Any(x => x.Id == id);
            if (!isExist)
                return new ApiResult(HttpStatusCode.NotFound, "Sipariş bulunamadı.");

            var result = _orderRepository.Delete(id).SaveChanges();
            if (!result)
                return new ApiResult(HttpStatusCode.BadRequest, "Bir sorun oluştu. Lütfen tekrar deneyiniz.");

            return new ApiResult(HttpStatusCode.OK, "Sipariş silindi.");

        }

        public ApiResult List(int offset, int limit)
        {
            var list = _orderRepository.GetAllAsNoTracking(offset, limit);
            if (!list.Any())
                return new ApiResult(HttpStatusCode.NotFound, "Sipariş bulunamadı.");

            var totalCount = _orderRepository.Count();
            return new ApiResult(HttpStatusCode.OK, list, "", totalCount);
        }

        public ApiResult Count()
        {
            var totalCount = _orderRepository.Count();
            return new ApiResult(HttpStatusCode.OK, totalCount);
        }
    }
}
