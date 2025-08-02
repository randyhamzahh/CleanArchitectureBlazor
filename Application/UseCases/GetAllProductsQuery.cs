namespace Application.UseCases;

using Core.Entities;
using Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

public class GetAllProductsQuery
{
    private readonly IProductRepository _productRepository;

    public GetAllProductsQuery(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Task<IEnumerable<Product>> ExecuteAsync()
    {
        return _productRepository.GetAllAsync();
    }
}