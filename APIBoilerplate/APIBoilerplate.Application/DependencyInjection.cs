using APIBoilerplate.Application.Services.Authentication.Commands;
using APIBoilerplate.Application.Services.Authentication.Querys;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace APIBoilerplate.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(DependencyInjection).Assembly);
            return services;
        }
    }
}