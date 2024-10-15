namespace POS.Domain.Models;

public class Receipt
{
    private Receipt(Guid id, DateTime dateIssued, decimal totalAmount, DateTime createdAt)
    {
        Id = id;
        DateIssued = dateIssued;
        TotalAmount = totalAmount;
        CreatedAt = createdAt;
    }

    public Guid Id { get; }
    public DateTime DateIssued { get; }
    public decimal TotalAmount { get; }
    public DateTime CreatedAt { get; }

    public static (Receipt Receipt, string Errors) Create(Guid id, DateTime dateIssued, decimal totalAmount,
        DateTime createdAt)
    {
        var errors = new List<string>
            {
                totalAmount <= 0 ? "Total amount must be greater than 0" : null,
                dateIssued > DateTime.Now ? "Date issued must be in the past" : null
            }
            .Where(e => e != null)
            .ToList();

        var receipt = new Receipt(id, dateIssued, totalAmount, createdAt);
        return (receipt, errors.Count > 0 ? string.Join("\n", errors) : string.Empty);
    }
}
