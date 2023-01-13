using APIBoilerplate.Application.Services.Authentication.Commands;
using APIBoilerplate.Application.Services.Authentication.Querys;
using APIBoilerplate.Contracts.Authentication;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using APIBoilerplate.Domain.Common.Errors;
using APIBoilerplate.Application.Services.Authentication.Common;

namespace APIBoilerplate.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationCommandService _authenticationCommandService;
    private readonly IAuthenticationQueryService _authenticationQueryService;

    public AuthenticationController(IAuthenticationCommandService authenticationCommandService,
                                    IAuthenticationQueryService authenticationQueryService)
    {
        _authenticationCommandService = authenticationCommandService;
        _authenticationQueryService = authenticationQueryService;
    }


    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    { 
        ErrorOr<AuthenticationResult> authResult = await _authenticationCommandService.RegisterAsync(request.FirstName, request.LastName, request.Email, request.Password);
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
        var authResult = await _authenticationQueryService.LogInAsync(request.Email, request.Password);
        

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