using APIBoilerplate.Application.Authentication.Common;
using APIBoilerplate.Application.Common.Interfaces.Authentication;
using APIBoilerplate.Application.Common.Interfaces.Persistence;
using APIBoilerplate.Domain.Common.Errors;
using APIBoilerplate.Domain.UserAggregate;
using ErrorOr;
using MediatR;

namespace APIBoilerplate.Application.Services.Authentication.Querys.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(
            LoginQuery query,
            CancellationToken cancellationToken)
        {
            if (await _userRepository.GetUserByEmailAsync(query.Email) is not User user)
            {
                return Errors.Authentication.InvalideCredentials;
            }

            if (user.Password != query.Password)
            {
                return Errors.Authentication.InvalideCredentials;
            }

            return new AuthenticationResult(
                user,
                _jwtTokenGenerator.GenerateToken(user.Id.Value, user.FirstName, user.LastName));
        }
    }
}