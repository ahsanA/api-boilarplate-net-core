using APIBoilerplate.Application.Common.Interfaces.Authentication;
using APIBoilerplate.Application.Common.Interfaces.Persistence;
using APIBoilerplate.Domain.Entities;
using ErrorOr;
using APIBoilerplate.Domain.Common.Errors;
using APIBoilerplate.Application.Services.Authentication.Common;

namespace APIBoilerplate.Application.Services.Authentication.Querys
{
    public class AuthenticationQueryService : IAuthenticationQueryService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
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