using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Services.Shared.Authentication.Helper;

namespace Services.Customer.Client.Base
{
    public static class CustomerApiClientDependencyInjectionExtensions
    {
        public static IServiceCollection AddCustomerApiClient(this IServiceCollection services, Action<CustomerServiceClientOptions> options)
        {
            services.AddOptions<CustomerServiceClientOptions>().Configure(options);
            services.AddTransient<CustomerClient>();
            services.AddHttpContextAccessor();
            services.TryAddTransient<HttpContextHelper>();
            return services;
        }
    }
}
