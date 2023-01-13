using APIBoilerplate.Domain.Entities;
using APIBoilerplate.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using APIBoilerplate.Application.Common.Interfaces.Persistence;
using APIBoilerplate.Application.Common.Interfaces.Authentication;
using APIBoilerplate.Application.Authentication.Common;

namespace APIBoilerplate.Application.Services.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
      
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }


        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command,
                                                                CancellationToken cancellationToken)
        {
            //check if user exists
            var userCheck = _userRepository.GetUserByEmailAsync(command.Email);
            if(userCheck is not null)
                if(userCheck.Result is User u)
                    return Errors.User.DuplicateEmail;

            //create user
            var user = new User{
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Password = command.Password
            };
            await _userRepository.AddAsync(user);

            //generate token
            
            var token = _jwtTokenGenerator.GenerateToken(user.Id, command.FirstName, command.LastName);
            
            return new AuthenticationResult(
                user,
                token
            );
        }
    }
}