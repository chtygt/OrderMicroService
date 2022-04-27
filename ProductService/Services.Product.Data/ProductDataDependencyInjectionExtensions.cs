using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Services.Product.Data
{
    public static class ProductDataDependencyInjectionExtensions
    {
        public static IServiceCollection AddProductDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProductDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("ProductDb")));
            return services;
        }
    }
}
