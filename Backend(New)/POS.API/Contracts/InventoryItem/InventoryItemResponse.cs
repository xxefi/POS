namespace POS.API.Contracts.InventoryItem;

public record InventoryItemResponse(
    Guid Id,
    string Name,
    int Quantity,
    decimal UnitPrice,
    DateTime ExpiryDate,
    Guid InventoryId);