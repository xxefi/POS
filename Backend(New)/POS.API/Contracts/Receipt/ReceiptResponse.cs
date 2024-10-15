namespace POS.API.Contracts.Receipt;

public record ReceiptResponse(
    Guid Id,
    DateTime DateIssued,
    decimal TotalAmount,
    Guid SaleId,
    Guid OrderId,
    DateTime CreatedAt);