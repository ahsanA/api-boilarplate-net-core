using APIBoilerplate.Application.Services.Authentication;
using APIBoilerplate.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace APIBoilerplate.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }


    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    { 
        var authResult = await _authenticationService.RegisterAsync(request.FirstName, request.LastName, request.Email, request.Password);
        
        var responce = new AuthenticationResponse(authResult.Id, authResult.FirstName, authResult.LastName, authResult.Email, authResult.Token);
        return Ok(responce);
    }

     [HttpPost("login")]
    public async Task<IActionResult> Login(LogInRequest request)
    { 
        var authResult = await _authenticationService.LogInAsync(request.Email, request.Password);
        
        var responce = new AuthenticationResponse(authResult.Id, authResult.FirstName, authResult.LastName, authResult.Email, authResult.Token);
        return Ok(responce);
    }
}