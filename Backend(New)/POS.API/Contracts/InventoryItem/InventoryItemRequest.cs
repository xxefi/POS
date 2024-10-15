namespace POS.API.Contracts.InventoryItem;

public record InventoryItemRequest(
    string Name,
    int Quantity,
    decimal UnitPrice,
    DateTime ExpiryDate,
    Guid InventoryId);