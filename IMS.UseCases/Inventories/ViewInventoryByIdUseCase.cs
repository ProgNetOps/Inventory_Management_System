using IMS.UseCases.Inventories.Interfaces;

namespace IMS.UseCases.Inventories;

public class ViewInventoryByIdUseCase(IInventoryRepository inventoryRepository) : IViewInventoryByIdUseCase
{
    private readonly IInventoryRepository _inventoryRepository = inventoryRepository;
    public async Task<Inventory> ExecuteAsync(int inventoryId)
    {
        return await _inventoryRepository.GetInventoryByIdAsync(inventoryId);
    }
}
