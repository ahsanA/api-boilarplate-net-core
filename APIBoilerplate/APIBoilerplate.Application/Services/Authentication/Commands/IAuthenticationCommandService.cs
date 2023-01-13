using APIBoilerplate.Application.Services.Authentication.Common;
using ErrorOr;

namespace APIBoilerplate.Application.Services.Authentication.Commands
{
    
    public interface IAuthenticationCommandService
    {
        Task<ErrorOr<AuthenticationResult>> RegisterAsync(string firstName, string lastName, string email, string password);
    }
}
