namespace POS.API.Contracts.Product;

public record ProductResponse(
    Guid Id,
    string Name,
    decimal UnitPrice,
    int Stock);