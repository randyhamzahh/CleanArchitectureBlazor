namespace Infrastructure.Repositories;

using Application.Interfaces;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ProductRepository : IProductRepository
{
    private readonly IApplicationDbContext _context;

    public ProductRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Product> AddAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task DeleteAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task UpdateAsync(Product product)
    {
        // The DbContext tracks the entity, so we just need to save changes.
        // For more complex scenarios, you might need to manage the entity's state.
        await _context.SaveChangesAsync();
    }
}
