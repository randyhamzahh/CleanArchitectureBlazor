namespace Application.UseCases;

using Application.DTOs;
using Core.Interfaces;
using System.Threading.Tasks;

public class UpdateProductCommand
{
    private readonly IProductRepository _productRepository;

    public UpdateProductCommand(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task ExecuteAsync(int id, ProductDto productDto)
    {
        var product = await _productRepository.GetByIdAsync(id);

        if (product == null)
        {
            // In a real app, you'd throw a custom NotFoundException here
            return;
        }

        product.Name = productDto.Name;
        product.Description = productDto.Description;
        product.Price = productDto.Price;

        await _productRepository.UpdateAsync(product);
    }
}
