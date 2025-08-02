namespace Application.UseCases;

using Core.Entities;
using Core.Interfaces;
using System.Threading.Tasks;

public class GetProductByIdQuery
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdQuery(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Task<Product?> ExecuteAsync(int id)
    {
        return _productRepository.GetByIdAsync(id);
    }
}