using APIBoilerplate.Application.Services.Authentication.Commands;
using APIBoilerplate.Application.Services.Authentication.Querys;
using Microsoft.Extensions.DependencyInjection;

namespace APIBoilerplate.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
            services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();
            return services;
        }
    }
}