using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Services.Shared.Models;

namespace Services.Shared.Authentication.Client
{
    public static class AuthenticationTokenDependencyInjectionExtensions
    {
        public static IServiceCollection AddAuthenticationTokenClientHelper(this IServiceCollection services, IConfiguration configuration)
        {
            var authOptions = configuration.GetSection("AuthenticationClientInfo").Get<AuthenticationOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ClockSkew = TimeSpan.Zero,
                        RequireExpirationTime = true,
                        ValidIssuer = authOptions.Issuer,
                        ValidAudience = authOptions.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(authOptions.Secret))
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = _ =>
                        {
                            //todo: add logging here
                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddAuthorization();
            return services;
        }
    }
}