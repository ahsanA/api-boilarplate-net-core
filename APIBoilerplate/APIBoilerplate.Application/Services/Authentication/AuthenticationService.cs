using APIBoilerplate.Application.Common.Interfaces.Authentication;

namespace APIBoilerplate.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public Task<AuthenticationResult> RegisterAsync(string firstName, string lastName, string email, string password)
        {
            //check if user exists

            //create user

            //generate token
            var userId = Guid.NewGuid();
            var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);
            
            return Task.FromResult(new AuthenticationResult(
                userId,
                "John",
                "Doe",
                email,
                token
            ));
        }
    
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

        }
}