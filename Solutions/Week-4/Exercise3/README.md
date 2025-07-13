# Custom Filters, Models, and Auth

## Overview
This ASP.NET Core Web assignment project demonstrates the following:

- Returning a list of custom class entities using a controller action.
- Usage of `[FromBody]` to read input models from POST request body.
- Implementing custom **authorization** and **exception** filters.
- Integrating Swagger UI for testing and documentation.

### Custom Model with Action Method

- Create `Employee`, `Department`, and `Skill` model classes.
- Action method returns a list of `Employee` objects.
- Uses `[HttpGet]`, `[AllowAnonymous]`, and `[ProducesResponseType]`.

### `[FromBody]` Usage

- The `POST` method reads the employee model from the body using `[FromBody]`.

### Custom Authorization Filter

- Checks for an `Authorization` header.
- If missing: returns **400 Bad Request** with message.
- If header does not contain `Bearer`: returns a different error message.

### Custom Exception Filter

- Captures unhandled exceptions.
- Logs exception details into `Logs/ErrorLog.txt`.
- Returns **500 Internal Server Error** with message `"An error occurred."`

---
## Installation & Setup
### **Install Dependencies**

```bash
dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson
dotnet add package Swashbuckle.AspNetCore
dotnet add package Microsoft.AspNetCore.Mvc.WebApiCompatShim
```
### **Running the Project**

```bash
dotnet build
dotnet run
```
Then open your browser:
```bash
http://localhost:<port>/swagger
```