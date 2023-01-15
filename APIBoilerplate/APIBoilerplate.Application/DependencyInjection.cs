using System.Reflection;
using APIBoilerplate.Application.Authentication.Commands.Register;
using APIBoilerplate.Application.Authentication.Common;
using APIBoilerplate.Application.Common.Behaviors;
using APIBoilerplate.Application.Services.Authentication.Commands.Register;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace APIBoilerplate.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(DependencyInjection).Assembly);
            
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}