using Microsoft.EntityFrameworkCore;
using RetailInventory.Models;

namespace RetailInventory.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Accessories" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Price = 55000M, CategoryId = 1 },
                new Product { Id = 2, Name = "Mouse", Price = 500M, CategoryId = 2 },
                new Product { Id = 3, Name = "Keyboard", Price = 1200M, CategoryId = 2 },
                new Product { Id = 4, Name = "Monitor", Price = 10000M, CategoryId = 1 },
                new Product { Id = 5, Name = "Tablet", Price = 15000M, CategoryId = 1 },
                new Product { Id = 6, Name = "Smartphone", Price = 25000M, CategoryId = 1 }
            );
        }
    }
}