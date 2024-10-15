using POS.Domain.Enums;

namespace POS.API.Contracts.Payment;

public record PaymentRequest(
    Guid OrderId,
    Guid CustomerId,
    decimal Amount,
    PaymentMethod PaymentMethod);