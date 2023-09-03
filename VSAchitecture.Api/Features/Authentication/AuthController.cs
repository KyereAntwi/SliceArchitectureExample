using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VSAchitecture.Api.Features.Authentication.Models;
using VSAchitecture.Api.Features.Authentication.Services;

namespace VSAchitecture.Api.Features.Authentication;

[Route("api/auth")]
[ApiController]
[AllowAnonymous]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [HttpPost("authenticate")]
    public async Task<ActionResult<AuthenticationResponse>> AuthenticateAsync([FromBody] AuthenticationRequest request)
    {
        return Ok(await _authService.AuthenticateAsync(request));
    }

    [HttpPost("register")]
    public async Task<ActionResult<RegistrationResponse>> RegisterAsync([FromBody] RegistrationRequest request)
    {
        return Ok(await _authService.RegisterAsync(request));
    }
}