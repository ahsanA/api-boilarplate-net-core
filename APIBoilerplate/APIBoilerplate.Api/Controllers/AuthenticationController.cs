using APIBoilerplate.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace APIBoilerplate.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    { 
        return Ok(request);
    }

     [HttpPost("login")]
    public IActionResult Login(LogInRequest request)
    { 
        return Ok(request);
    }
}