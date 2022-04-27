using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Services.Shared.Authentication.Helper;

namespace Services.Order.Client.Base
{
    public static class OrderApiClientDependencyInjectionExtensions
    {
        public static IServiceCollection AddOrderApiClient(this IServiceCollection services, Action<OrderServiceClientOptions> options)
        {
            services.AddOptions<OrderServiceClientOptions>().Configure(options);
            services.AddTransient<OrderClient>();
            services.AddTransient<OrderItemClient>();
            services.AddHttpContextAccessor();
            services.TryAddTransient<HttpContextHelper>();
            return services;
        }
    }
}
