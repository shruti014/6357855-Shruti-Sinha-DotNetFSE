using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RetailInventory.Data;
using RetailInventory.DTOs;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var services = new ServiceCollection();

services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

var serviceProvider = services.BuildServiceProvider();
using var context = serviceProvider.GetRequiredService<AppDbContext>();

// STEP 1: Filter and Sort
var filtered = await context.Products
    .Where(p => p.Price > 1000)
    .OrderByDescending(p => p.Price)
    .ToListAsync();

Console.WriteLine("Filtered and Sorted Products:");
foreach (var product in filtered)
{
    Console.WriteLine($"Name: {product.Name}, Price: {product.Price}");
}

// STEP 2: Project into DTO
var productDTOs = await context.Products
    .Select(p => new ProductDTO
    {
        Name = p.Name,
        Price = p.Price
    })
    .ToListAsync();

Console.WriteLine("\nProjected DTOs:");
foreach (var dto in productDTOs)
{
    Console.WriteLine($"Name: {dto.Name}, Price: {dto.Price}");
}