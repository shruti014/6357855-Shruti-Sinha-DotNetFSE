using RetailInventory.Models;
using Microsoft.EntityFrameworkCore;

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