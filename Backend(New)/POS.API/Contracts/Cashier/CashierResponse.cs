namespace POS.API.Contracts.Cashier;

public record CashierResponse(
    Guid Id,
    string Name,
    string Email,
    string Phone,
    string Brand);