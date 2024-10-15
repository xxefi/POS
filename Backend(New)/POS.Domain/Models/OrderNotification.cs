namespace POS.Domain.Models;

public class OrderNotification
{
    public const int MAX_MESSAGE_LENGTH = 256;

    private OrderNotification(Guid id, string message, bool isRead, DateTime createdAt)
    {
        Id = id;
        Message = message;
        IsRead = isRead;
        CreatedAt = createdAt;
    }

    public Guid Id { get; }
    public string Message { get; }
    public bool IsRead { get; }
    public DateTime CreatedAt { get; }

    public static (OrderNotification OrderNotification, string Error) Create(Guid id, string message, bool isRead)
    {
        var errors = new List<string>
            {
                string.IsNullOrWhiteSpace(message) ? "Message cannot be empty" : null,
                message.Length > MAX_MESSAGE_LENGTH ? $"Message cannot exceed {MAX_MESSAGE_LENGTH} characters" : null
            }
            .Where(e => e != null)
            .ToList();

        var orderNotification = new OrderNotification(id, message, isRead, DateTime.UtcNow);
        return (orderNotification, errors.Count > 0 ? string.Join("\n", errors) : string.Empty);
    }
}