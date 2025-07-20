using System.Security.Claims;

namespace exercise2.Services;

public interface IJwtService
{
    string GenerateToken(string username, string role = "User");
}