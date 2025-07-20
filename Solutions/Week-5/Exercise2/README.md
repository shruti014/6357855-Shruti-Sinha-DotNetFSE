# ASP.NET Core Web API – JWT Authentication & Authorization

## Overview
This project demonstrates how to implement secure login and role-based access using **JWT (JSON Web Tokens)** in an ASP.NET Core Web API. It includes:

- JWT authentication
- Securing API endpoints
- Role-based access control
- Expired token handling
- Dependency Injection for JWT logic
---
## Configuration

### `appsettings.json`

```json
{
  "Jwt": {
    "Key": "<YOUR_SECRET_KEY>",
    "Issuer": "MyAuthServer",
    "Audience": "MyApiUsers",
    "DurationInMinutes": 60
  }
}
```
> Ensure the JWT key is at least 32 characters long to satisfy HS256 requirements.

### Question 1: Implement JWT Authentication
#### GOAL
Issue a JWT token after successful login.

**Steps**
- Add `LoginModel.cs` for login credentials.
- Create `IJwtService` and `JwtService` using DI.
- Implement `/api/auth/login` endpoint in `AuthController`.
- Use `SymmetricSecurityKey` to sign the token.

### Question 2: Secure an API Endpoint Using JWT
#### GOAL
Restrict access to an endpoint with `[Authorize]`.

**Steps**
- Add `SecureController.cs`.
- Use `[Authorize]` attribute.

*Example:*
```csharp
[Authorize]
[HttpGet("data")]
public IActionResult GetSecureData()
{
    var username = User.Identity?.Name;
    return Ok($"Hello {username}, this is protected data.");
}
```

### Question 3: Add Role-Based Authorization
#### GOAL
Allow only `Admin` role users to access a specific route.

**Steps:**
- Add `"Admin"` to token claims during login.
- Add `[Authorize(Roles = "Admin")]` to controller.

*Example:*
```csharp
[Authorize(Roles = "Admin")]
[HttpGet("dashboard")]
public IActionResult GetAdminDashboard()
{
    return Ok("Welcome to the Admin Dashboard");
}
```

### Question 4: Validate JWT Expiry and Handle Unauthorized Access
#### GOAL
Detect expired tokens and return custom headers.

**Steps:**
In `Program.cs`, configure JWT Bearer events:
```csharp
options.Events = new JwtBearerEvents
{
    OnAuthenticationFailed = context =>
    {
        if (context.Exception is SecurityTokenExpiredException)
        {
            context.Response.Headers.Add("Token-Expired", "true");
        }
        return Task.CompletedTask;
    }
};
```