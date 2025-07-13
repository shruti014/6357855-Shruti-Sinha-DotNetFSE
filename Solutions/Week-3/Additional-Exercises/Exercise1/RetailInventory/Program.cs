using RetailInventory.Models;
using Microsoft.EntityFrameworkCore;

using var context = new RetailDbContext();

// Products
var products_old = await context.Products.Include(p => p.Category).ToListAsync();
Console.WriteLine("\nProducts:");
foreach (var p in products_old)
{
    Console.WriteLine($"{p.Name} - ₹{p.Price} - {p.Stock} units - Category: {p.Category?.CategoryName}");
}

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

// DISPLAY remaining products
var updatedProducts = await context.Products.Include(p => p.Category).ToListAsync();
Console.WriteLine("\nRemaining Products:");
foreach (var p in updatedProducts)
{
    Console.WriteLine($"{p.Name} - ₹{p.Price} - {p.Stock} units - Category: {p.Category?.CategoryName}");
}