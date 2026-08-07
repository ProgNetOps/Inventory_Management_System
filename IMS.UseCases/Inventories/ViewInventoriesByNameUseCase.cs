
namespace IMS.UseCases.Inventories;

public class ViewInventoriesByNameUseCase(IInventoryRepository inventoryRepository)
{
    private readonly IInventoryRepository _inventoryRepository= inventoryRepository;

    public async Task<IEnumerable<Inventory>> ExecuteAsync(string name = "")
    {
        return await _inventoryRepository.GetInventoriesByNameAsync(name);
    }
}
