using Services.Shared.Client;
using Microsoft.Extensions.Options;
using RestSharp;
using Services.Customer.Client.Base;
using Services.Customer.Client.Interfaces;
using Services.Shared.Authentication.Helper;
using Services.Shared.Models;

namespace Services.Customer.Client
{
    public class CustomerClient : ClientBase, ICustomerClient
    {
        public CustomerClient(HttpContextHelper httpContext, IOptions<CustomerServiceClientOptions> options)
              : base(httpContext.LoggedUser.AccessToken, options.Value)
        {
        }

        public ServiceResult Add(Model.Customer model)
        {
            var request = CreateRequest<ServiceResult>(CustomerApiConstants.CustomerAdd, model, Method.Post);
            return HandleResponse(request);
        }

        public ServiceResult<Model.Customer> Get(Guid customerId)
        {
            var request = CreateRequest<ServiceResult<Model.Customer>>(CustomerApiConstants.CustomerGet, null, Method.Get,
                new UrlSegmentParam() { Name = "id", Value = customerId });
            return HandleResponse(request);
        }
        public ServiceResult Update(Model.Customer model)
        {
            var request = CreateRequest<ServiceResult>(CustomerApiConstants.CustomerUpdate, model, Method.Post);
            return HandleResponse(request);
        }

        public ServiceResult Delete(Guid customerId)
        {
            var request = CreateRequest<ServiceResult>(CustomerApiConstants.CustomerDelete, null, Method.Delete,
                new UrlSegmentParam() { Name = "id", Value = customerId });
            return HandleResponse(request);
        }

        public ServiceResult<List<Model.Customer>> List(int offset = 0, int limit = 1000)
        {
            var request = CreateRequest<ServiceResult<List<Model.Customer>>>(CustomerApiConstants.CustomerList, null, Method.Get,
                new UrlSegmentParam() { Name = "offset", Value = offset },
                new UrlSegmentParam() { Name = "limit", Value = limit });
            return HandleResponse(request);
        }



        public ServiceResult Count()
        {
            var request = CreateRequest<ServiceResult>(CustomerApiConstants.CustomerCount, null, Method.Get);
            return HandleResponse(request);
        }
    }
}
