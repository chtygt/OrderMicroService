using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Services.Report.Data
{
    public static class ReportDataDependencyInjectionExtensions
    {
        public static IServiceCollection AddReportDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ReportDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("ReportDb")));
            return services;
        }
    }
}
