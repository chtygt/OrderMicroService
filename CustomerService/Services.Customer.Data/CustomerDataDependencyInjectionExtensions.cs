using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Services.Customer.Data
{
    public static class CustomerDataDependencyInjectionExtensions
    {
        public static IServiceCollection AddCustomerDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CustomerDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("CustomerDb")));
            return services;
        }

    }
}
