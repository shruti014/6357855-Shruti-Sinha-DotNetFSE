# Inventory Management System with EF Core - Updating and Deleting Records

## Overview

This lab demonstrates how to **update** and **delete records** using **Entity Framework Core** in a .NET Console Application for a retail store.
---
## Objective

- Update the price of a product (`Laptop`)
- Delete a product (`Rice Bag`) from the database
---
## Prerequisites

Ensure you have:
- [.NET 6+ SDK](https://dotnet.microsoft.com/en-us/download)
- EF Core packages installed:
  ```bash
  dotnet add package Microsoft.EntityFrameworkCore.SqlServer
  dotnet add package Microsoft.EntityFrameworkCore.Design
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
```
### Database Models

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

`RetailDbContext.cs`
```csharp
public class RetailDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Your_Connection_String_Here");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, CategoryName = "Electronics" },
            new Category { CategoryId = 2, CategoryName = "Grocery" }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product { ProductId = 1, Name = "Laptop", Price = 65000, Stock = 10, CategoryId = 1 },
            new Product { ProductId = 2, Name = "Phone", Price = 55000, Stock = 90, CategoryId = 1 },
            new Product { ProductId = 3, Name = "Rice Bag", Price = 1500, Stock = 50, CategoryId = 2 },
            new Product { ProductId = 4, Name = "Ice Cream", Price = 90, Stock = 500, CategoryId = 2 }
        );
    }
}
```
### Updation and Deletion Logic

`Program.cs`
```csharp
using RetailInventory.Models;
using Microsoft.EntityFrameworkCore;

using var context = new RetailDbContext();

// UPDATE: Change Laptop price to 100000
var product = await context.Products.FirstOrDefaultAsync(p => p.Name == "Laptop");
if (product != null)
{
    product.Price = 100000;
    await context.SaveChangesAsync();
    Console.WriteLine("\nUpdated Laptop price to 1,00,000 Rs.");
}

// DELETE: Remove Rice Bag
var toDelete = await context.Products.FirstOrDefaultAsync(p => p.Name == "Rice Bag");
if (toDelete != null)
{
    context.Products.Remove(toDelete);
    await context.SaveChangesAsync();
    Console.WriteLine("Deleted product: Rice Bag.");
}
```