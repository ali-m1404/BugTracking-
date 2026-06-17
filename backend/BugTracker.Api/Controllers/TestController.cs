using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    [HttpGet("public")]
    public IActionResult Public()
    {
        return Ok("Public Endpoint");
    }

    [Authorize]
    [HttpGet("profile")]
    public IActionResult Profile()
    {
        return Ok("Authenticated User");
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("admin-only")]
    public IActionResult AdminOnly()
    {
        return Ok("Welcome Admin");
    }

    [Authorize(Roles = "ProjectManager")]
    [HttpGet("manager-only")]
    public IActionResult ManagerOnly()
    {
        return Ok("Welcome Project Manager");
    }

    [Authorize(Roles = "Developer")]
    [HttpGet("developer-only")]
    public IActionResult DeveloperOnly()
    {
        return Ok("Welcome Developer");
    }

    [Authorize(Roles = "Tester")]
    [HttpGet("tester-only")]
    public IActionResult TesterOnly()
    {
        return Ok("Welcome Tester");
    }
}