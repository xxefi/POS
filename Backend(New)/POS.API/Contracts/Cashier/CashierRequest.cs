namespace POS.API.Contracts.Cashier;

public record CashierRequest(
    string Name,
    string Email,
    string Phone,
    string PinCode,
    string Brand);