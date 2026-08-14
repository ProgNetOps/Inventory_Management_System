
using IMS.UseCases.Inventories.Interfaces;

namespace IMS.UseCases.Inventories;

/// <summary>
/// Use Case for adding a new inventory to the data store
/// </summary>
public class AddInventoryUseCase(IInventoryRepository inventoryRepository) : IAddInventoryUseCase
{
    private readonly IInventoryRepository _inventoryRepository = inventoryRepository;

    /// <summary>
    /// Takes an inventory parameter and insert it to the data store
    /// </summary>
    /// <returns></returns>
    public async Task ExecuteAsync(Inventory inventory)
    {
        await _inventoryRepository.AddInventoryAsync(inventory);
    }
}
