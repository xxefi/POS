namespace POS.API.Contracts.Receipt;

public record ReceiptRequest(
    Guid SaleId,
    Guid OrderId,
    decimal TotalAmount);