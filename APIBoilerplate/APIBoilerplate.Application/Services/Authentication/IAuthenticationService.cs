namespace APIBoilerplate.Application.Services.Authentication
{
    using ErrorOr;
    public interface IAuthenticationService
    {
        Task<ErrorOr<AuthenticationResult>> LogInAsync(string email, string password);
        Task<ErrorOr<AuthenticationResult>> RegisterAsync(string firstName, string lastName, string email, string password);
    }
}
