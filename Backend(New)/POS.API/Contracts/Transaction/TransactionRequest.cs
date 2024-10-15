namespace POS.API.Contracts.Transaction;

public record TransactionRequest(
    Guid CustomerId,
    decimal Amount,
    DateTime TransactionDate,
    string TransactionType,
    string Description);