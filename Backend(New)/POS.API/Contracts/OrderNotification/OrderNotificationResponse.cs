namespace POS.API.Contracts.OrderNotification;

public record OrderNotificationResponse(
    Guid Id,
    string Message,
    bool IsRead,
    DateTime CreatedAt,
    Guid OrderId);