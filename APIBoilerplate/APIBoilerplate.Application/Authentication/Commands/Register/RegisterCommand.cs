using APIBoilerplate.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace APIBoilerplate.Application.Services.Authentication.Commands.Register
{
    public record RegisterCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password): IRequest<ErrorOr<AuthenticationResult>>;
}