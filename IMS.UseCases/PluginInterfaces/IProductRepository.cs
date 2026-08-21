namespace IMS.UseCases.PluginInterfaces;

public interface IProductRepository
{
    Task AddProductAsync(Product product);
    Task DeleteProductByIdAsync(int productId);
    Task<IEnumerable<Product>> GetInventoriesByNameAsync(string name);
    Task<Product?> GetProductByIdAsync(int productId);
    Task UpdateProductAsync(Product product);
}
