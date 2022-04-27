using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Services.Order.Data
{
    public static class OrderDataDependencyInjectionExtensions
    {
        public static IServiceCollection AddOrderDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("OrderDb")));
            return services;
        }
    }
}
