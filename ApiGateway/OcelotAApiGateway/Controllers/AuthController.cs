using Microsoft.AspNetCore.Mvc;
using OcelotAApiGateway.Models;
using OcelotAApiGateway.Services;

namespace OcelotAApiGateway.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly JwtTokenService _jwtTokenService;

    public AuthController(JwtTokenService jwtTokenService)
    {
        _jwtTokenService = jwtTokenService;
    }

    [HttpPost]
    public IActionResult Login([FromBody] LoginModel user)
    {
        var loginResult = _jwtTokenService.GenerateAuthToken(user);

        return loginResult is null ? Unauthorized() : Ok(loginResult);
    }
}
