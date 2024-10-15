using POS.Domain.Enums;

namespace POS.Domain.Entities;

public class OrderEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid TableId { get; set; }
    public decimal TotalAmount { get; set; }
    public OrderStatus Status { get; set; }
    public TableEntity Table { get; set; }
    public ICollection<OrderItemEntity> OrderItems { get; set; } = [];
    public ICollection<PaymentEntity> Payments { get; set; } = [];
    public ICollection<OrderNotificationEntity> Notifications { get; set; } = [];
    public ICollection<ReceiptEntity>? Receipts { get; set; } = [];
    public ICollection<RefundEntity>? Refunds { get; set; }
}
