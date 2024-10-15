namespace POS.API.Contracts.Sale;

public record SaleRequest(
    DateTime SaleDate,
    decimal TotalAmount,
    Guid CustomerId);