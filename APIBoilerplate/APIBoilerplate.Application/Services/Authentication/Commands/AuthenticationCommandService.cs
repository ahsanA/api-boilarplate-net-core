using APIBoilerplate.Application.Common.Interfaces.Authentication;
using APIBoilerplate.Application.Common.Interfaces.Persistence;
using APIBoilerplate.Domain.Entities;
using ErrorOr;
using APIBoilerplate.Domain.Common.Errors;
using APIBoilerplate.Application.Services.Authentication.Common;

namespace APIBoilerplate.Application.Services.Authentication.Commands
{
    public class AuthenticationCommandService : IAuthenticationCommandService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
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
    
        }
}