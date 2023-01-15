
using APIBoilerplate.Api.Common.Errors;
using APIBoilerplate.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace APIBoilerplate.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPrasentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>();
            services.AddMappings();
            
            return services;
        }
    }
}