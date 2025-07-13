# Writing Queries with LINQ
## Objective: 

Use `Where`, `OrderBy`, `Select` and project product data into DTOs using **Entity Framework Core LINQ queries**.
---

## Overview

This lab demonstrates how to:
- Filter products based on conditions
- Sort them by price
- Project the result into a lightweight Data Transfer Object (DTO)
---

## Technologies Used

- [.NET 6+ SDK](https://dotnet.microsoft.com/en-us/download)
- Entity Framework Core
- LINQ (`Where`, `OrderBy`, `Select`)
- SQL Server LocalDB
---

## LINQ Query Steps

### Step 1: Filter and Sort Products
```csharp
var filtered = await context.Products
    .Where(p => p.Price > 1000)
    .OrderByDescending(p => p.Price)
    .ToListAsync();
```

### Step 2: Project into DTO
```csharp
var productDTOs = await context.Products
    .Select(p => new ProductDTO
    {
        Name = p.Name,
        Price = p.Price
    })
    .ToListAsync();
```