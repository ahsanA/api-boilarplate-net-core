namespace APIBoilerplate.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResult> LogInAsync(string email, string password);
        Task<AuthenticationResult> RegisterAsync(string firstName, string lastName, string email, string password);
    }
}
