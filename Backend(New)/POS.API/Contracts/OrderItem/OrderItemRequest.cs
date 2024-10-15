namespace POS.API.Contracts.OrderItem;

public record OrderItemRequest(
    Guid OrderId,
    string ProductName,
    int Quantity,
    decimal Price);