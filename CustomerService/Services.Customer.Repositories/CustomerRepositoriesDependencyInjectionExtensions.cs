using Microsoft.Extensions.DependencyInjection;
using Services.Customer.Repositories.Interfaces;
using Services.Customer.Repositories.Repositories;

namespace Services.Customer.Repositories
{
    public static class CustomerRepositoriesDependencyInjectionExtensions
    {
        public static IServiceCollection AddCustomerDataRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            return services;
        }
    }
}
