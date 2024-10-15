using POS.Domain.Enums;

namespace POS.Domain.Models;

public class Order
{
    private Order(Guid id, DateTime createdAt, Guid tableId, decimal totalAmount, OrderStatus status)
    {
        Id = id;
        CreatedAt = createdAt;
        TableId = tableId;
        TotalAmount = totalAmount;
        Status = status;
    }

    public Guid Id { get; }
    public DateTime CreatedAt { get; }
    public Guid TableId { get; }
    public decimal TotalAmount { get; }
    public OrderStatus Status { get; }

    public static (Order Order, string Errors) Create(Guid id, DateTime createdAt, Guid tableId, decimal totalAmount, OrderStatus status)
    {
        var errors = new List<string>
            {
                totalAmount < 0 ? "Total amount cannot be negative" : null,
                !Enum.IsDefined(typeof(OrderStatus), status) ? "Invalid order status" : null
            }
            .Where(e => e != null)
            .ToList();

        var order = new Order(id, createdAt, tableId, totalAmount, status);
        return (order, errors.Count > 0 ? string.Join("\n", errors) : string.Empty);
    }
}