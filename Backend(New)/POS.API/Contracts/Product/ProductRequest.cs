namespace POS.API.Contracts.Product;

public record ProductRequest(
    string Name,
    decimal UnitPrice,
    int Stock);