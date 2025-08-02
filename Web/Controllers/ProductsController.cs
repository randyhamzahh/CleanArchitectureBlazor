namespace Web.Controllers;

using Application.DTOs;
using Application.UseCases;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly GetProductByIdQuery _getProductByIdQuery;
    private readonly GetAllProductsQuery _getAllProductsQuery;
    private readonly CreateProductCommand _createProductCommand;
    private readonly UpdateProductCommand _updateProductCommand;
    private readonly DeleteProductCommand _deleteProductCommand;

    public ProductsController(
        GetProductByIdQuery getProductByIdQuery,
        GetAllProductsQuery getAllProductsQuery,
        CreateProductCommand createProductCommand,
        UpdateProductCommand updateProductCommand,
        DeleteProductCommand deleteProductCommand)
    {
        _getProductByIdQuery = getProductByIdQuery;
        _getAllProductsQuery = getAllProductsQuery;
        _createProductCommand = createProductCommand;
        _updateProductCommand = updateProductCommand;
        _deleteProductCommand = deleteProductCommand;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        var products = await _getAllProductsQuery.ExecuteAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var product = await _getProductByIdQuery.ExecuteAsync(id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<Product>> PostProduct(ProductDto productDto)
    {
        var newProduct = await _createProductCommand.ExecuteAsync(productDto);
        return CreatedAtAction(nameof(GetProduct), new { id = newProduct.Id }, newProduct);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduct(int id, ProductDto productDto)
    {
        await _updateProductCommand.ExecuteAsync(id, productDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        await _deleteProductCommand.ExecuteAsync(id);
        return NoContent();
    }
}