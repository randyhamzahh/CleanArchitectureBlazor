namespace Application.UseCases;

using Application.DTOs;
using Core.Entities;
using Core.Interfaces;
using System.Threading.Tasks;

public class CreateProductCommand
{
    private readonly IProductRepository _productRepository;

    public CreateProductCommand(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> ExecuteAsync(ProductDto productDto)
    {
        var product = new Product
        {
            Name = productDto.Name,
            Description = productDto.Description,
            Price = productDto.Price
        };

        return await _productRepository.AddAsync(product);
    }
}