namespace Application.Interfaces;

using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public interface IApplicationDbContext
{
    DbSet<Product> Products { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}