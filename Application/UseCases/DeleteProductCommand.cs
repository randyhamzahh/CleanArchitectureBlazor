namespace Application.UseCases;

using Core.Interfaces;
using System.Threading.Tasks;

public class DeleteProductCommand
{
    private readonly IProductRepository _productRepository;

    public DeleteProductCommand(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task ExecuteAsync(int id)
    {
        await _productRepository.DeleteAsync(id);
    }
}