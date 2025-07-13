using Microsoft.EntityFrameworkCore;
using RetailInventory.Models;

public class RetailDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=RetailDb;Trusted_Connection=True;TrustServerCertificate=True");
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