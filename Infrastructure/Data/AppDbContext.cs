namespace Infrastructure.Data;

using Application.Interfaces;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext, IApplicationDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed some initial data for testing
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Laptop", Description = "A powerful laptop for all your needs.", Price = 1200.00m },
            new Product { Id = 2, Name = "Mouse", Description = "A comfortable ergonomic mouse.", Price = 45.50m },
            new Product { Id = 3, Name = "Keyboard", Description = "A mechanical keyboard with RGB.", Price = 99.99m }
        );
    }
}