
using IMS.UseCases.Products.Interfaces;

namespace IMS.UseCases.Inventories;

public class DeleteProductUseCase(IProductRepository productRepository) : IDeleteProductUseCase
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task ExecuteAsync(int productId)
    {
        await _productRepository.DeleteProductByIdAsync(productId);
    }

}
