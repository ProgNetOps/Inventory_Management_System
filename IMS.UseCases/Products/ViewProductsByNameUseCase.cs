
using IMS.UseCases.Products.Interfaces;

namespace IMS.UseCases.Inventories;

public class ViewProductsByNameUseCase(IProductRepository productRepository) : IViewProductsByNameUseCase
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<IEnumerable<Product>> ExecuteAsync(string name = "")
    {
        return await _productRepository.GetProductsByNameAsync(name);
    }
}
