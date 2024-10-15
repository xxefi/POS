namespace POS.API.Contracts.OrderNotification;

public record OrderNotificationRequest(
    string Message,
    bool IsRead,
    Guid OrderId);