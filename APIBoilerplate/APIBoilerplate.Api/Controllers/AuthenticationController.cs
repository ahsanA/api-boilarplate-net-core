using APIBoilerplate.Contracts.Authentication;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using APIBoilerplate.Application.Services.Authentication.Commands.Register;
using APIBoilerplate.Application.Authentication.Common;
using APIBoilerplate.Application.Services.Authentication.Querys.Login;
using APIBoilerplate.Domain.Common.Errors;

namespace APIBoilerplate.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly ISender sender;

    public AuthenticationController(ISender sender)
    {
        this.sender = sender;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    { 
        var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);
        ErrorOr<AuthenticationResult> authResult = await sender.Send(command);
        return authResult.Match<IActionResult>(
            authResult => Ok(PopulateResponse(authResult)),
            errors => Problem(errors)
        );
    }

    private static AuthenticationResponse PopulateResponse(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(authResult.User.Id,
                                                  authResult.User.FirstName,
                                                  authResult.User.LastName,
                                                  authResult.User.Email,
                                                  authResult.Token);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LogInRequest request)
    { 
        var query = new LoginQuery(request.Email, request.Password);
        var authResult = await sender.Send(query);
        

        if(authResult.IsError && authResult.FirstError == Errors.Authentication.InvalideCredentials)
        {
            return Problem( statusCode: StatusCodes.Status401Unauthorized,
                            title: authResult.FirstError.Description);
        }

        return authResult.Match<IActionResult>(
            authResult => Ok(PopulateResponse(authResult)),
            errors => Problem(errors)
        );        
    }
}