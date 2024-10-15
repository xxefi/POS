using POS.API.Contracts.InventoryItem;

namespace POS.API.Contracts.Inventory;

public record InventoryResponse(
    Guid Id,
    string IngredientName,
    int Quantity,
    Guid InventoryItemId,
    ICollection<InventoryItemResponse> InventoryItems);