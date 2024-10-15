namespace POS.Domain.Models;

public class Refund
{
    private Refund(Guid id, DateTime refundDate, decimal amount, DateTime createdAt)
    {
        Id = id;
        RefundDate = refundDate;
        Amount = amount;
        CreatedAt = createdAt;
    }

    public Guid Id { get; }
    public DateTime RefundDate { get; }
    public decimal Amount { get; }
    public DateTime CreatedAt { get; }

    public static (Refund Refund, string Errors) Create(Guid id, DateTime refundDate, decimal amount)
    {
        var errors = new List<string>
            {
                amount <= 0 ? "Amount must be greater than 0" : null,
                refundDate > DateTime.UtcNow ? "Refund date cannot be in the future" : null
            }
            .Where(e => e != null)
            .ToList();

        var refund = new Refund(id, refundDate, amount, DateTime.UtcNow);
        return (refund, errors.Count > 0 ? string.Join("\n", errors) : string.Empty);
    }
}