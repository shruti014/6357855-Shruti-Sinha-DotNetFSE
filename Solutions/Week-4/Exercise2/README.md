# Swagger Demo Web API (.NET Core)

## Objectives 
### Swagger Installation in Web API
- Added `Swashbuckle.AspNetCore` NuGet package
- Configured `Startup.cs` with `AddSwaggerGen()` and `UseSwaggerUI()`
- Used `ProducesResponseType` for better API documentation

### Postman Usage
- Sent `GET` and `POST` requests to test the Web API
- Explored Postman tabs: `Params`, `Headers`, `Body`, `Tests`
- Added JSON request in body
- Verified status codes and response in the output pane

### Route Customization
- Renamed route to `api/Employee`
- Used `[ActionName]` to assign user-friendly names to action methods
---
## Setup 
### Create Project

```bash
dotnet new webapi -n exercise2
cd exercise2
```

### Install Swagger Package

```bash
dotnet add package Swashbuckle.AspNetCore
```

### Startup.cs Configuration

- `ConfigureServices` Method
    ```csharp
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Title = "Swagger Demo",
            Version = "v1",
            Description = "TBD",
            TermsOfService = new Uri("https://example.com"),
            Contact = new Microsoft.OpenApi.Models.OpenApiContact
            {
                Name = "John Doe",
                Email = "john@xyzmail.com",
                Url = new Uri("https://www.example.com")
            },
            License = new Microsoft.OpenApi.Models.OpenApiLicense
            {
                Name = "License Terms",
                Url = new Uri("https://www.example.com")
            }
        });
    });
    ```
- `Configure` Method
    ```csharp
    app.UseSwagger();

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Demo");
    });

    app.UseRouting();
    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
    ```
---
### EmployeeController

`Controllers/EmployeeController.cs`
```csharp
using Microsoft.AspNetCore.Mvc;

namespace exercise2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private static readonly List<string> employees = new()
        {
            "Alice", "Bob", "Charlie"
        };

        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult Get()
        {
            return Ok(employees);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public IActionResult Post([FromBody] string name)
        {
            employees.Add(name);
            return Created("", name);
        }
    }
}
```
---
## Running the App
```bash
dotnet run
```
Visit:
```bash
http://localhost:<port>/swagger
```
You’ll see:
- Swagger Title, Version, and Contact
- API operations: `GET`, `POST`, and `GET /first`
- Interactive *Try it out* feature