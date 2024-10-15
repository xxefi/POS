namespace POS.API.Contracts.Refund;

public record RefundRequest(
    decimal Amount,
    Guid SaleId,
    Guid OrderId);