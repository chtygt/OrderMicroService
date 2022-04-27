using Microsoft.Extensions.DependencyInjection;
using Services.Product.Repositories.Interfaces;
using Services.Product.Repositories.Repositories;

namespace Services.Product.Repositories
{
    public static class ProductRepositoriesDependencyInjectionExtensions
    {
        public static IServiceCollection AddProductDataRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
