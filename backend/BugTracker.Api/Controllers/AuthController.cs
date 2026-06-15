
using BugTracker.Api.DTOs.Auth;
using BugTracker.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequestDto request)
    {
        try
        {
            await _authService.RegisterAsync(request);

            return Ok(new
            {
                Message = "User registered successfully."
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                Message = ex.Message
            });
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequestDto request)
    {
        var result = await _authService.LoginAsync(request);

        if (result == null)
        {
            return Unauthorized(new
            {
                Message = "Invalid email or password."
            });
        }

        return Ok(result);
    }
}