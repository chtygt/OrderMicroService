using System.Net;
using Microsoft.EntityFrameworkCore;
using Services.Customer.Repositories.Interfaces;
using Services.Shared.Models;

namespace Services.Customer.Api.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public ApiResult Get(Guid id)
        {
            var customer = _customerRepository.FirstOrDefault(x => x.Id == id);
            if (customer == null)
                return new ApiResult(HttpStatusCode.NotFound, "Müşteri bulunamadı.");

            return new ApiResult(HttpStatusCode.OK, customer);
        }


        public ApiResult Add(Model.Customer customer)
        {
            var result = _customerRepository.Add(customer).SaveChanges();
            if (!result)
                return new ApiResult(HttpStatusCode.BadRequest, "Bilinmeyen bir hata oluştu. Lütfen tekrar deneyiniz.");

            return new ApiResult(HttpStatusCode.OK, "Müşteri eklendi.");
        }

        public ApiResult Update(Model.Customer customer)
        {
            var isExist = _customerRepository.Any(x => x.Id == customer.Id);
            if (!isExist)
                return new ApiResult(HttpStatusCode.NotFound, "Müşteri bulunamadı");

            bool result;
            try
            {
                result = _customerRepository.Update(customer).SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                return new ApiResult(HttpStatusCode.BadRequest, e.Message);
            }
            if (!result)
                return new ApiResult(HttpStatusCode.BadRequest, "Bilinmeyen bir hata oluştu. Lütfen tekrar deneyiniz.");

            return new ApiResult(HttpStatusCode.OK, "Müşteri güncellendi.");
        }

        public ApiResult Delete(Guid id)
        {
            var isExist = _customerRepository.Any(x => x.Id == id);
            if (!isExist)
                return new ApiResult(HttpStatusCode.NotFound, "Müşteri bulunamadı.");

            var result = _customerRepository.Delete(id).SaveChanges();
            if (!result)
                return new ApiResult(HttpStatusCode.BadRequest, "Bilinmeyen bir hata oluştu. Lütfen tekrar deneyiniz.");

            return new ApiResult(HttpStatusCode.OK, "Müşteri silindi.");

        }

        public ApiResult List(int offset, int limit)
        {
            var list = _customerRepository.GetAllAsNoTracking(offset, limit);
            if (!list.Any())
                return new ApiResult(HttpStatusCode.NotFound, "Müşteri bulunamadı.");

            var totalCount = _customerRepository.Count();
            return new ApiResult(HttpStatusCode.OK, list, "", totalCount);
        }

        public ApiResult Count()
        {
            var totalCount = _customerRepository.Count();
            return new ApiResult(HttpStatusCode.OK, totalCount);
        }
    }
}
