using POS.Domain.Enums;

namespace POS.API.Contracts.Payment;

public record PaymentResponse(
    Guid Id,
    Guid OrderId,
    Guid CustomerId,
    decimal Amount,
    PaymentMethod PaymentMethod);