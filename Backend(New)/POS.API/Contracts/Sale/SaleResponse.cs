using POS.API.Contracts.Customer;

namespace POS.API.Contracts.Sale;

public record SaleResponse(
    Guid Id,
    DateTime SaleDate,
    decimal TotalAmount,
    Guid CustomerId,
    CustomerResponse? Customer);