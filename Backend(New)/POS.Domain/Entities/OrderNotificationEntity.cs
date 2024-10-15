namespace POS.Domain.Entities;

public class OrderNotificationEntity
{
    public Guid Id { get; set; }
    public string Message { get; set; } = string.Empty;
    public bool IsRead { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid OrderId { get; set; }
    public OrderEntity? Order { get; set; }
}
