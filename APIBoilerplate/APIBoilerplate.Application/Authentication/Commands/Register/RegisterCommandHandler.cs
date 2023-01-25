using APIBoilerplate.Application.Authentication.Common;
using APIBoilerplate.Application.Common.Interfaces.Authentication;
using APIBoilerplate.Application.Common.Interfaces.Persistence;
using APIBoilerplate.Domain.Common.Errors;
using APIBoilerplate.Domain.UserAggregate;
using ErrorOr;
using MediatR;

namespace APIBoilerplate.Application.Services.Authentication.Commands.Register
{
    public class RegisterCommandHandler :
        IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public RegisterCommandHandler(
            IUserRepository userRepository,
            IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(
            RegisterCommand command,
            CancellationToken cancellationToken)
        {
            // check if user exists
            if (await _userRepository.GetUserByEmailAsync(command.Email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }

            // create user
            var user = User.Create(command.FirstName, command.LastName, command.Email, command.Password);
            await _userRepository.AddAsync(user);

            // generate token
            var token = _jwtTokenGenerator.GenerateToken(user.Id.Value, command.FirstName, command.LastName);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}