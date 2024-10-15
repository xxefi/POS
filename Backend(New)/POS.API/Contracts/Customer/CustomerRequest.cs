namespace POS.API.Contracts.Customer;

public record CustomerRequest(
    string FullName,
    string Email,
    string PhoneNumber);