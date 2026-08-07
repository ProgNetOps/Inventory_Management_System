using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory;

public class InventoryRepository : IInventoryRepository
{
    private readonly List<Inventory> _inventories;

    public InventoryRepository()
    {
        _inventories = new()
        {
            new Inventory{
            InventoryId=1,InventoryName="Bike Seat",Quantity=10,Price=2},
            new Inventory{
            InventoryId=2,InventoryName="Bike Body",Quantity=10,Price=15},
            new Inventory{
            InventoryId=3,InventoryName="Bike Wheels",Quantity=20,Price=8},
            new Inventory{
            InventoryId=4,InventoryName="Bike Pedals",Quantity=20,Price=1}
        };
    }

    public Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
    {
        throw new NotImplementedException();
    }
}
