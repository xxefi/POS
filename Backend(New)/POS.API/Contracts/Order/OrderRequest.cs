using POS.API.Contracts.OrderItem;
using POS.Domain.Enums;

namespace POS.API.Contracts.Order;

public record OrderRequest(
    Guid TableId,
    decimal TotalAmount,
    OrderStatus Status,
    ICollection<OrderItemRequest> OrderItems);