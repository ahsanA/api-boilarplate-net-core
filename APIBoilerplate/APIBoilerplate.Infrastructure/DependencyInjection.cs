using APIBoilerplate.Application.Common.Interfaces.Authentication;
using APIBoilerplate.Application.Common.Interfaces.Persistence;
using APIBoilerplate.Application.Common.Interfaces.Services;
using APIBoilerplate.Infrastructure.Authentication;
using APIBoilerplate.Infrastructure.Persistence;
using APIBoilerplate.Infrastructure.Persistence.Repositories;
using APIBoilerplate.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace APIBoilerplate.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            ConfigurationManager configuration)
        {
            services
                .AddAuth(configuration)
                .AddPersistance();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            return services;
        }

        public static IServiceCollection AddPersistance(this IServiceCollection services)
        {
            services.AddDbContext<APIBoilerplateDbContext>(options =>
                options.UseSqlServer("Data Source=(local);Initial Catalog=APIBoilerplate;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")); // "Server=(localdb)\\mssqllocaldb;Database=APIBoilerplate;Trusted_Connection=True;MultipleActiveResultSets=true"
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICowRepository, CowRepository>();
            return services;
        }

        public static IServiceCollection AddAuth(
            this IServiceCollection services,
            ConfigurationManager configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.Bind(JwtSettings.SectionName, jwtSettings);
            services.AddSingleton(Options.Create(jwtSettings));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtSettings.Secret)),
                });

            return services;
        }
    }
}