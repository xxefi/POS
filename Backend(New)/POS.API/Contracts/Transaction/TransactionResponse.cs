namespace POS.API.Contracts.Transaction;

public record TransactionResponse(
    Guid Id,
    Guid CustomerId,
    decimal Amount,
    DateTime TransactionDate,
    string TransactionType,
    string Description);