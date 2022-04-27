using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Shared.Models;

namespace Services.Shared.Authentication
{
    public static class AuthenticationTokenDependencyInjectionExtensions
    {
        public static IServiceCollection AddAuthenticationTokenServerHelper(this IServiceCollection services, IConfiguration configuration)
        {
            var s = configuration.GetSection("AuthenticationServerInfo");
            services.Configure<AuthenticationOptions>(s);
            services.AddSingleton<AuthenticationServerHelper>();
            return services;
        }
    }
}
