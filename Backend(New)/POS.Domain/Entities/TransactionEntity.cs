namespace POS.Domain.Entities;

public class TransactionEntity
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public decimal Amount { get; set; }
    public DateTime TransactionDate { get; set; }
    public string TransactionType { get; set; } = string.Empty; 
    public string Description { get; set; } = string.Empty;
    public ICollection<CustomerEntity> Customers { get; set; } = [];
}
