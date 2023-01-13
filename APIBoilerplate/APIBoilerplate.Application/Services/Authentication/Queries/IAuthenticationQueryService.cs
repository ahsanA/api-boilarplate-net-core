using APIBoilerplate.Application.Services.Authentication.Common;
using ErrorOr;

namespace APIBoilerplate.Application.Services.Authentication.Querys
{
    
    public interface IAuthenticationQueryService
    {
        Task<ErrorOr<AuthenticationResult>> LogInAsync(string email, string password);
    }
}
