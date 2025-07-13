# Setting Up the Database Context for a Retail Store
## Objective

This assignment demonstrates how to configure a `DbContext` class in a .NET console application using Entity Framework Core to connect to a SQL Server database. It sets up entity models for `Product` and `Category`, and initializes the connection using a connection string.
---

## Prerequisites

Ensure you have:
- [.NET 6+ SDK](https://dotnet.microsoft.com/en-us/download)
- SQL Server or SQL Server Express installed
- EF Core CLI Tools installed:
  ```bash
  dotnet tool install --global dotnet-ef
  ```
---
## Project Setup

```bash
dotnet new console -n RetailInventory
cd RetailInventory
```
*Add EF Core:*
```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.Extensions.Configuration
dotnet add package Microsoft.Extensions.Configuration.Json
dotnet add package Microsoft.Extensions.DependencyInjection
```
### Entity Models

`Models/Product.cs`
```csharp
public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
```

`Models/Category.cs`
```csharp
public class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }

    public List<Product> Products { get; set; }
}
```

### Setup `AppDbContext`
`Data/AppDbContext.cs`
```csharp
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RetailInventory.Models;

namespace RetailInventory.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
```
### Add Configuration File

`appsettings.json`
```csharp
{
  "ConnectionStrings": {
    "DefaultConnection": "Your_Connection_String_Here"
  }
}
```

### Configure `Program.cs`
```csharp
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RetailInventory.Data;

namespace RetailInventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Load configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Setup DI
            var services = new ServiceCollection()
                .AddSingleton<IConfiguration>(configuration)
                .AddDbContext<AppDbContext>()
                .BuildServiceProvider();

            using var context = services.GetService<AppDbContext>();

            Console.WriteLine("Database context initialized using appsettings.json");
        }
    }
}
```

### Migrations and Database Creation
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```