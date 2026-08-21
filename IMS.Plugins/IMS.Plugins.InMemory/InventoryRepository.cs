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

    public Task AddInventoryAsync(Inventory inventory)
    {
        //Check if the inventory already exists, by name
        if(_inventories.Any(x => x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
        {
            return Task.CompletedTask;
        }
        else
        {
            //Get the last Id and increment it to generate an id for the new inventory
            var maxId = _inventories.Max(x => x.InventoryId);
            inventory.InventoryId = maxId + 1;
            _inventories.Add(inventory);
            return Task.CompletedTask;
        }
    }

    public Task DeleteInventoryByIdAsync(int inventoryId)
    {
        var inventory = _inventories.FirstOrDefault(x=>x.InventoryId == inventoryId);
        if(inventory != null)
        {
            _inventories.Remove(inventory);
        }

        return Task.CompletedTask;
    }

    public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name) is true)
        {
            return await Task.FromResult(_inventories);
        }
        else
        {
            return _inventories.Where(x => x.InventoryName.Contains(name,StringComparison.OrdinalIgnoreCase));
        }
    }

    public async Task<Inventory?> GetInventoryByIdAsync(int inventoryId)
    {
        return await Task.FromResult(_inventories.FirstOrDefault(x=>x.InventoryId == inventoryId));
    }

    public Task UpdateInventoryAsync(Inventory inventory)
    {
        if(_inventories.Any(x=>inventory.InventoryId !=x.InventoryId &&
        x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
        {
            return Task.CompletedTask;
        }

        var invToUpdate = _inventories.FirstOrDefault(x => x.InventoryId==inventory.InventoryId);
        if(invToUpdate is not null)
        {
            invToUpdate.InventoryName = inventory.InventoryName;
            invToUpdate.Price = inventory.Price;
            invToUpdate.Quantity = inventory.Quantity;
        }


        return Task.CompletedTask;
    }
}
