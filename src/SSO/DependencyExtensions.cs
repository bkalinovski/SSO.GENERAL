using System;
using SSO.Contract;
using SSO.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SSO.Repository;
using SSO.Options;

namespace SSO
{
    public static class DependencyExtensions
    {
        public static IServiceCollection AddSsoServices(this IServiceCollection services, Action<AuthServiceOptions> configureOptions)
        {
            configureOptions = configureOptions ?? throw new ArgumentNullException(nameof(configureOptions));

            services.Configure(configureOptions);

            services.AddSingleton<IPostConfigureOptions<AuthServiceOptions>, AuthServiceOptionsPostConfigure>();

            services.AddScoped<AuthDBContext>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
