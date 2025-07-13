# Inventory Management System with EF Core
## What is ORM?

ORM (Object-Relational Mapping) is a technique to:
- Map C# classes to database tables
- Map C# properties to table columns

### Example

```csharp
public class Product {
    public int Id { get; set; }
    public string Name { get; set; }
}
```
> EF Core automatically maps this to a SQL table `Products` with columns `Id` and `Name`.

### Advantages of ORM

- Avoid writing raw SQL
- Simplifies Data access
- Reduces errors
- Easier to maintain
- Supports Migrations
---
## Entity Framework Core (EF Core) Vs Entity Framework (EF)

| Feature       | EF Core                                     | EF6 (.NET Framework)          |
| ------------- | ------------------------------------------- | ----------------------------- |
| Platform      | Cross-platform (.NET 6/7/8)                 | Windows-only (.NET Framework) |
| Performance   | Faster, lightweight                         | Slower, mature                |
| LINQ Support  | Yes                                         | Yes                           |
| Async Queries | Excellent support                         | Limited                     |
| New Features  | JSON columns, interceptors, compiled models | No recent updates           |
---

## EF Core 8.0 Key Features

- *JSON Column Mapping:* Save nested objects in a JSON-formatted column.
- *Compiled Models:* Improves startup and runtime performance.
- *Interceptors:* Hook into SQL execution for logging/security.
- *Bulk Updates:* More efficient batch operations.
---

##  Create .NET Console App

```bash
dotnet new console -n RetailInventory
cd RetailInventory
```
### Install EF Core Packages

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
```

### Define Models

`Models/Product.cs`
```csharp
namespace RetailInventory.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
```

`Models/Category.cs`
```csharp
namespace RetailInventory.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Product> Products { get; set; }
    }
}
```
### Define DbContext

`RetailDbContext.cs`
```csharp
using Microsoft.EntityFrameworkCore;
using RetailInventory.Models;

public class RetailDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Your_Connection_String_Here");
    }
}
```

### Create Initial Migration

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### Example Usage

```csharp
using RetailInventory.Models;

class Program
{
    static void Main()
    {
        using var context = new RetailDbContext();

        var electronics = new Category { CategoryName = "Electronics" };
        context.Categories.Add(electronics);

        var product = new Product { Name = "Smartphone", Stock = 50, Category = electronics };
        context.Products.Add(product);

        context.SaveChanges();

        var products = context.Products.Include(p => p.Category).ToList();
        foreach (var p in products)
            Console.WriteLine($"{p.Name} - {p.Stock} units - Category: {p.Category.CategoryName}");
    }
}
```

### Run the App

```bash
dotnet run
```
---
## Output

```bash
Smartphone - 50 units - Category: Electronics
```