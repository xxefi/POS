namespace POS.API.Contracts.Account;

public record AccountRequest(
    string Username,
    string Email,
    string Password,
    Guid CustomerId);