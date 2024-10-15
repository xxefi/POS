namespace POS.API.Contracts.MenuItem;

public record MenuItemRequest(
    string Name,
    string Description,
    decimal Price,
    int Quantity,
    Guid CategoryId);