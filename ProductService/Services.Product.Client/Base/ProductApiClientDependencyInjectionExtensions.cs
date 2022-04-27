using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Services.Shared.Authentication.Helper;

namespace Services.Product.Client.Base
{
    public static class ProductApiClientDependencyInjectionExtensions
    {
        public static IServiceCollection AddProductApiClient(this IServiceCollection services, Action<ProductServiceClientOptions> options)
        {
            services.AddOptions<ProductServiceClientOptions>().Configure(options);
            services.AddTransient<ProductClient>();
            services.AddHttpContextAccessor();
            services.TryAddTransient<HttpContextHelper>();
            return services;
        }
    }
}
