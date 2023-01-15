using APIBoilerplate.Api;
using APIBoilerplate.Application;
using APIBoilerplate.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPrasentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
    
}


var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
