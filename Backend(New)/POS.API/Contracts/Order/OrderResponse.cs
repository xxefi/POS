using POS.API.Contracts.OrderItem;
using POS.API.Contracts.OrderNotification;
using POS.API.Contracts.Payment;
using POS.API.Contracts.Receipt;
using POS.API.Contracts.Refund;
using POS.Domain.Enums;

namespace POS.API.Contracts.Order;

public record OrderResponse(
    Guid Id,
    DateTime CreatedAt,
    Guid TableId,
    decimal TotalAmount,
    OrderStatus Status,
    ICollection<OrderItemResponse> OrderItems,
    ICollection<PaymentResponse> Payments,
    ICollection<OrderNotificationResponse> Notifications,
    ICollection<ReceiptResponse>? Receipts,
    ICollection<RefundResponse>? Refunds);