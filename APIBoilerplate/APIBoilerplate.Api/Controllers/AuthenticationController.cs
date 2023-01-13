using APIBoilerplate.Application.Services.Authentication;
using APIBoilerplate.Contracts.Authentication;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using APIBoilerplate.Domain.Common.Errors;

namespace APIBoilerplate.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }


    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    { 
        ErrorOr<AuthenticationResult> authResult = await _authenticationService.RegisterAsync(request.FirstName, request.LastName, request.Email, request.Password);
        return authResult.Match<IActionResult>(
            authResult => Ok(PopulateResponse(authResult)),
            errors => Problem(errors)
        );
    }

    private static AuthenticationResponse PopulateResponse(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(authResult.Id,
                                                  authResult.FirstName,
                                                  authResult.LastName,
                                                  authResult.Email,
                                                  authResult.Token);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LogInRequest request)
    { 
        var authResult = await _authenticationService.LogInAsync(request.Email, request.Password);
        

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