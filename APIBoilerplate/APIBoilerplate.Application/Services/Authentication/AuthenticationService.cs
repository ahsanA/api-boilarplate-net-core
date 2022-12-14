namespace APIBoilerplate.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        public Task<AuthenticationResult> LogInAsync(string email, string password)
        {
            return Task.FromResult(new AuthenticationResult(
                Guid.NewGuid(),
                "John",
                "Doe",
                email,
                "someToken"
            ));
        }

        public Task<AuthenticationResult> RegisterAsync(string firstName, string lastName, string email, string password)
        {
            return Task.FromResult(new AuthenticationResult(
                Guid.NewGuid(),
                "John",
                "Doe",
                email,
                "someToken"
            ));
        }
    }
}