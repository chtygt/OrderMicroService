using Microsoft.Extensions.DependencyInjection;
using Services.Report.Repositories.Interfaces;
using Services.Report.Repositories.Repositories;

namespace Services.Report.Repositories
{
    public static class ReportRepositoriesDependencyInjectionExtensions
    {
        public static IServiceCollection AddOrderDataRepositories(this IServiceCollection services)
        {
            services.AddScoped<IOrderLocationReportRepository, OrderLocationReportRepository>();
            return services;
        }

    }
}
