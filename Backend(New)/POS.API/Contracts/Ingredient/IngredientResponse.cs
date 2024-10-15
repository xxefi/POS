using POS.API.Contracts.MenuItem;

namespace POS.API.Contracts.Ingredient;

public record IngredientResponse(
    Guid Id,
    string Name,
    decimal Quantity,
    decimal UnitPrice,
    ICollection<MenuItemResponse> MenuItems);