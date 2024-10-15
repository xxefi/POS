namespace POS.API.Contracts.OrderItem;

public record OrderItemResponse(
    Guid Id,
    Guid OrderId,
    string ProductName,
    int Quantity,
    decimal Price);