using APIBoilerplate.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace APIBoilerplate.Application.Services.Authentication.Querys.Login
{
    public record LoginQuery(       
        string Email,
        string Password): IRequest<ErrorOr<AuthenticationResult>>;
}