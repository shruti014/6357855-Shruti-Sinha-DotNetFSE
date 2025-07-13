# Use EF Core CLI to Create and Apply Migrations
## Objective

Learn how to use the **Entity Framework Core CLI** to:
- Generate database schema changes
- Apply migrations to SQL Server
- Seed initial data
- Verify table creation in SQL Server Management Studio (SSMS) or Azure Data Studio
---

## Prerequisites

Ensure you have:
- [.NET 6+ SDK](https://dotnet.microsoft.com/en-us/download)
- Visual Studio / VS Code
- EF Core packages installed
- SQL Server or SQL Server Express installed
---

## Models Used

### Category.cs

```csharp
public class Category
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<Product>? Products { get; set; }
}
```

### Product.cs

```csharp
public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}
```
---
## EF Core CLI Steps
### Install EF Core CLI

```bash
dotnet tool install --global dotnet-ef
```
> Verify installation using:
```bash
dotnet ef --version
```

### Create Initial Migration

```bash
dotnet ef migrations add InitialCreate
```
> This generates a `Migrations/` folder with the schema definition.

### Apply Migration and Create Database
```bash
dotnet ef database update
```
> This creates the database and tables based on the models.

### Verify in SQL Server
- Open *SQL Server Management Studio (SSMS)* or *Azure Data Studio*
- Connect to:
    ```SCSS
    (localdb)\MSSQLLocalDB
    ```
- Check that the database *RetailDb* has been created
- Verify that the tables *Products* and *Categories* exist under `Tables`
---

## NOTES
- If you encounter the error:
    `"There is already an object named 'Categories' in the database"`
    - Run:
        ```bash
        dotnet ef database drop
        dotnet ef database update
        ```
- Seed initial data in `OnModelCreating()` using `HasData()` for testing