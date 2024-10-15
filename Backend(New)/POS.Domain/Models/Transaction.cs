namespace POS.Domain.Models;

public class Transaction
{
    private Transaction(Guid id, Guid customerId, decimal amount, DateTime transactionDate, string transactionType, string description)
    {
        Id = id;
        CustomerId = customerId;
        Amount = amount;
        TransactionDate = transactionDate;
        TransactionType = transactionType;
        Description = description;
    }
    public Guid Id { get; }
    public Guid CustomerId { get; }
    public decimal Amount { get; }
    public DateTime TransactionDate { get; }
    public string TransactionType { get;}
    public string Description { get;}
    
    public static (Transaction Transaction, string Errors) Create(Guid id, Guid customerId, decimal amount, DateTime transactionDate, string transactionType, string description)
    {
        var errors = new List<string>
            {
                amount < 0 ? "Amount cannot be negative" : null,
                string.IsNullOrWhiteSpace(transactionType) ? "Transaction type cannot be empty" : null,
                transactionDate > DateTime.UtcNow ? "Transaction date cannot be in the future" : null
            }
            .Where(e => e != null)
            .ToList();

        var transaction = new Transaction(id, customerId, amount, transactionDate, transactionType, description);
        return (transaction, errors.Count > 0 ? string.Join("\n", errors) : string.Empty);
    }
}