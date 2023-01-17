using APIBoilerplate.Contracts.Authentication;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using APIBoilerplate.Application.Services.Authentication.Commands.Register;
using APIBoilerplate.Application.Authentication.Common;
using APIBoilerplate.Application.Services.Authentication.Querys.Login;
using APIBoilerplate.Domain.Common.Errors;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;

namespace APIBoilerplate.Api.Controllers;

[Route("auth")]
[AllowAnonymous]
public class AuthenticationController : ApiController
{
    private readonly ISender sender;
    private readonly IMapper mapper;

    public AuthenticationController(ISender sender, IMapper mapper)
    {
        this.sender = sender;
        this.mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    { 
        var command = mapper.Map<RegisterCommand>(request);
        ErrorOr<AuthenticationResult> authResult = await sender.Send(command);
        return authResult.Match<IActionResult>(
            authResult => Ok(mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors)
        );
    }

   

    [HttpPost("login")]
    public async Task<IActionResult> Login(LogInRequest request)
    { 
        var query = mapper.Map<LoginQuery>(request);
        var authResult = await sender.Send(query);
        

        if(authResult.IsError && authResult.FirstError == Errors.Authentication.InvalideCredentials)
        {
            return Problem( statusCode: StatusCodes.Status401Unauthorized,
                            title: authResult.FirstError.Description);
        }

        return authResult.Match<IActionResult>(
            authResult => Ok(mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors)
        );        
    }
}