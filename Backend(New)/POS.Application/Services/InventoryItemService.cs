using POS.Domain.Abstractions.Repositories;
using POS.Domain.Abstractions.Services;
using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Application.Services;

public class InventoryItemService : IInventoryItemService
{
    private readonly IInventoryItemRepository _inventoryItemRepository;

    public InventoryItemService(IInventoryItemRepository inventoryItemRepository)
        => _inventoryItemRepository = inventoryItemRepository;
    
    public async Task<ICollection<InventoryItem>> GetAllInventoryItemsAsync()
    {
        return await _inventoryItemRepository.GetAllAsync();
    }

    public async Task<InventoryItem> GetInventoryItemByIdAsync(Guid inventoryItemId)
    {
        return await _inventoryItemRepository.GetByIdAsync(inventoryItemId);
    }

    public async Task AddInventoryItemAsync(InventoryItemEntity item)
    {
        await _inventoryItemRepository.AddAsync(item);
    }

    public async Task UpdateInventoryItemAsync(InventoryItem item)
    {
        var existingInventoryItem = await _inventoryItemRepository.GetByIdAsync(item.Id);
        await _inventoryItemRepository.Update(existingInventoryItem);
    }

    public async Task RemoveInventoryItemAsync(Guid inventoryItemId)
    {
        var existingInventoryItem = await _inventoryItemRepository.GetByIdAsync(inventoryItemId);
        await _inventoryItemRepository.Remove(existingInventoryItem);
    }
}