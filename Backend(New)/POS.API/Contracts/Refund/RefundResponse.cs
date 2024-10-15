namespace POS.API.Contracts.Refund;

public record RefundResponse(
    Guid Id,
    decimal Amount,
    DateTime RefundDate,
    Guid SaleId,
    Guid OrderId,
    DateTime CreatedAt);