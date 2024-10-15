namespace POS.API.Contracts.Inventory;

public record InventoryRequest(
    string IngredientName,
    int Quantity,
    Guid InventoryItemId);