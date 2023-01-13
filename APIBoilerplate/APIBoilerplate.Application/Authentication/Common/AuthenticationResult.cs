using APIBoilerplate.Domain.Entities;

namespace APIBoilerplate.Application.Authentication.Common
{
    public record AuthenticationResult(
        User User,
        string Token);
}