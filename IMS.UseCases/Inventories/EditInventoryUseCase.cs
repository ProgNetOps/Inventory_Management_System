using IMS.UseCases.Inventories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.Inventories
{
    public class EditInventoryUseCase(IInventoryRepository inventoryRepository) : IEditInventoryUseCase
    {
        private readonly IInventoryRepository _inventoryRepository = inventoryRepository;

        public async Task ExecuteAsync(Inventory inventory)
        {
            await _inventoryRepository.UpdateInventoryAsync(inventory);
        }
    }
}
