using exercise2.Models;
using exercise2.Services;
using Microsoft.AspNetCore.Mvc;

namespace exercise2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IJwtService _jwtService;

    public AuthController(IJwtService jwtService)
    {
        _jwtService = jwtService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel model)
    {
        if (IsValidUser(model, out string role))
        {
            var token = _jwtService.GenerateToken(model.Username, role);
            return Ok(new { Token = token });
        }
        return Unauthorized("Invalid credentials");
    }

    private bool IsValidUser(LoginModel model, out string role)
    {
        // Hardcoded user validation for demonstration purposes
        if (model.Username == "admin" && model.Password == "admin123")
        {
            role = "Admin";
            return true;
        }
        else if (model.Username == "user" && model.Password == "user123")
        {
            role = "User";
            return true;
        }

        role = string.Empty;
        return false;
    }
}