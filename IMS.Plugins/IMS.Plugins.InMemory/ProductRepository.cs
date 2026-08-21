using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory;

public class ProductRepository : IProductRepository
{
    private readonly List<Product> _products;
  
    public ProductRepository()
    {
        _products = new()
        {
            new Product{
            ProductId=1,ProductName="Bike Seat",Quantity=10,Price=2},
            new Product{
            ProductId=2,ProductName="Bike Body",Quantity=10,Price=15},
            new Product{
            ProductId=3,ProductName="Bike Wheels",Quantity=20,Price=8},
            new Product{
            ProductId=4,ProductName="Bike Pedals",Quantity=20,Price=1}
        };
    }

    public Task AddProductAsync(Product Product)
    {
        //Check if the Product already exists, by name
        if(_products.Any(x => x.ProductName.Equals(Product.ProductName, StringComparison.OrdinalIgnoreCase)))
        {
            return Task.CompletedTask;
        }
        else
        {
            //Get the last Id and increment it to generate an id for the new Product
            var maxId = _products.Max(x => x.ProductId);
            Product.ProductId = maxId + 1;
            _products.Add(Product);
            return Task.CompletedTask;
        }
    }

    public Task DeleteProductByIdAsync(int ProductId)
    {
        var Product = _products.FirstOrDefault(x=>x.ProductId == ProductId);
        if(Product != null)
        {
            _products.Remove(Product);
        }

        return Task.CompletedTask;
    }

    public async Task<IEnumerable<Product>> GetproductsByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name) is true)
        {
            return await Task.FromResult(_products);
        }
        else
        {
            return _products.Where(x => x.ProductName.Contains(name,StringComparison.OrdinalIgnoreCase));
        }
    }

    public async Task<Product?> GetProductByIdAsync(int ProductId)
    {
        return await Task.FromResult(_products.FirstOrDefault(x=>x.ProductId == ProductId));
    }

    public Task UpdateProductAsync(Product Product)
    {
        if(_products.Any(x=>Product.ProductId !=x.ProductId &&
        x.ProductName.Equals(Product.ProductName, StringComparison.OrdinalIgnoreCase)))
        {
            return Task.CompletedTask;
        }

        var invToUpdate = _products.FirstOrDefault(x => x.ProductId==Product.ProductId);
        if(invToUpdate is not null)
        {
            invToUpdate.ProductName = Product.ProductName;
            invToUpdate.Price = Product.Price;
            invToUpdate.Quantity = Product.Quantity;
        }


        return Task.CompletedTask;
    }
}
