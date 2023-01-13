using APIBoilerplate.Application.Common.Interfaces.Authentication;
using APIBoilerplate.Application.Common.Interfaces.Persistence;
using APIBoilerplate.Domain.Entities;
using ErrorOr;
using APIBoilerplate.Domain.Common.Errors;

namespace APIBoilerplate.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> RegisterAsync(string firstName, string lastName, string email, string password)
        {
            //check if user exists
            var userCheck = _userRepository.GetUserByEmailAsync(email);
            if(userCheck is not null)
                if(userCheck.Result is User u)
                    return Errors.User.DuplicateEmail;

            //create user
            var user = new User{
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };
            await _userRepository.AddAsync(user);

            //generate token
            
            var token = _jwtTokenGenerator.GenerateToken(user.Id, firstName, lastName);
            
            return new AuthenticationResult(
                user.Id,
                firstName,
                lastName,
                email,
                token
            );
        }
    
        public async Task<ErrorOr<AuthenticationResult>> LogInAsync(string email, string password)
        {
            //check if user exists
           
            if(await _userRepository.GetUserByEmailAsync(email) is not User user)
                return Errors.Authentication.InvalideCredentials;
            
            if(user.Password != password)
                return Errors.Authentication.InvalideCredentials;

                
            return new AuthenticationResult(
                user.Id,
                user.FirstName,
                user.LastName,
                user.Email,
                _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName)
            );
        }

        }
}