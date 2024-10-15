namespace POS.API.Contracts.Account;

public record AccountResponse(
    Guid Id,
    string Username,
    string Email,
    Guid CustomerId);