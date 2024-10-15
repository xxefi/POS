using POS.API.Contracts.Order;

namespace POS.API.Contracts.Table;

public record TableResponse(
    Guid Id,
    int number,
    bool isBusy,
    ICollection<OrderResponse> Orders);