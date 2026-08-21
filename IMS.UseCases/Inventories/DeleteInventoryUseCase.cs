using IMS.UseCases.Inventories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.Inventories;

public class DeleteInventoryUseCase(IInventoryRepository inventoryRepository) : IDeleteInventoryUseCase
{
    private readonly IInventoryRepository _inventoryRepository = inventoryRepository;

    public async Task ExecuteAsync(int inventoryId)
    {
        await _inventoryRepository.DeleteInventoryByIdAsync(inventoryId);
    }

}
