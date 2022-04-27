using Microsoft.Extensions.DependencyInjection;
using Services.Order.Repositories.Interfaces;
using Services.Order.Repositories.Repositories;

namespace Services.Order.Repositories
{
    public static class OrderRepositoriesDependencyInjectionExtensions
    {
        public static IServiceCollection AddOrderDataRepositories(this IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            return services;
        }
    }
}
