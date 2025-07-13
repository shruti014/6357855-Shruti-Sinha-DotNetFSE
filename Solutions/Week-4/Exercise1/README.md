# Web API using .NET Core

## Objectives

This assignment demonstrates the creation of a simple **RESTful Web API** in **.NET Core** with full **Read/Write support**, aligned with the following objectives.

### RESTful Web Service, Web API & Microservice

- **REST (Representational State Transfer):**
  - Stateless communication over HTTP
  - Resources identified by URIs
  - Uses standard HTTP methods (GET, POST, PUT, DELETE)
  - Responses not limited to XML; JSON preferred

- **Web API:**
  - Lightweight framework to build RESTful HTTP services
  - Returns data (usually JSON) to clients like browsers or mobile apps

- **Microservice:**
  - Independently deployable, small services
  - Communicate via APIs (often REST)
  - Each service handles a specific business function

#### WebService vs WebAPI

| Feature            | WebService (SOAP) | WebAPI (REST)        |
|--------------------|-------------------|-----------------------|
| Protocol           | SOAP               | HTTP/HTTPS            |
| Data Format        | XML only           | JSON, XML, etc.       |
| Lightweight        | No                 | Yes                |
| Use Case           | Enterprise apps    | Web/mobile apps       |

### HttpRequest & HttpResponse

- **HttpRequest:** Sent by the client to request data or perform actions.
- **HttpResponse:** Sent by the server to return data, status, or error.

Example:
```http
POST /api/items
Request Body: { "name": "Notebook" }

Response: 201 Created
Response Body: { "id": 1, "name": "Notebook" }
```

### Action Verbs (HTTP Methods)

| Verb   | Description  | Attribute in Web API |
| ------ | ------------ | -------------------- |
| GET    | Fetch data   | `[HttpGet]`          |
| POST   | Add new data | `[HttpPost]`         |
| PUT    | Update data  | `[HttpPut]`          |
| DELETE | Delete data  | `[HttpDelete]`       |

###  HTTP Status Codes
| Code | Meaning               | Method Usage                  |
| ---- | --------------------- | ----------------------------- |
| 200  | OK                    | `return Ok(data);`            |
| 201  | Created               | `return CreatedAtAction(...)` |
| 400  | Bad Request           | `return BadRequest();`        |
| 401  | Unauthorized          | `return Unauthorized();`      |
| 500  | Internal Server Error | `return StatusCode(500);`     |

### Simple Web API: Read & Write

#### Structure

- *Controller:* Inherits from `ApiController`
- *Actions:* Defined using action verbs

`Controllers/ItemsController.cs`
```csharp
[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    public ItemsController()
    {
        Console.WriteLine("\nItemsController loaded\n");
    }

    private static List<Item> items = new()
    {
        new Item { Id = 1, Name = "Pen" },
        new Item { Id = 2, Name = "Book" }
    };

    [HttpGet]
    public IActionResult Get() => Ok(items);

    [HttpPost]
    public IActionResult Post(Item item)
    {
        item.Id = items.Count + 1;
        items.Add(item);
        return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
    }
}
```

### Test API with Postman
#### GET
- *Method:* `GET`
- *URL:* `http://localhost:<post>/api/items`
#### POST
- *Method:* `POST`
- *URL:* `http://localhost:<post>/api/items`
- *Body:* `raw` -> *JSON*
    ```json
    {
        "name": "Notebook"
    }
    ```

### Configuration Files in Web API
| File                                          | Description                                                |
| --------------------------------------------- | ---------------------------------------------------------- |
| **Startup.cs** or `Program.cs`                | Configures services, middleware (dependency injection)     |
| **appsettings.json**                          | App-level config: connection strings, secrets              |
| **launchSettings.json**                       | Debug profiles for Kestrel, IIS Express                    |
| **Web.config / RouteConfig.cs (ASP.NET 4.5)** | For older .NET Framework apps, define routing and settings |
| **WebApiConfig.cs (.NET 4.5)**                | Register HTTP routes for APIs                              |

### CLI Steps to Create API
```bash
dotnet new webapi -n <Api_Name>
cd <Api_Name>
```
#### Add Model

`Models/Item.cs`
```csharp
public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
}
```
#### Add Controller
Show Above in *README* section *Structure* sub-section`Controllers/ItemsController.cs`

#### Run
```bash
dotnet run
```
---
## Result
- `GET /api/items` returns item list
- `POST /api/items` returns item list
---
## Summary
This assignment shows how to:
- Build a RESTful API using ASP.NET Core
- Use CLI to create a new project
- Understand HTTP verbs, status codes, request/response
- Define a model and controller