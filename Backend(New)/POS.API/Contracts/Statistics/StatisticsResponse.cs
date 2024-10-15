using POS.API.Contracts.Inventory;
using POS.API.Contracts.Sale;

namespace POS.API.Contracts.Statistics;

public record StatisticsResponse(
    Guid Id,
    DateTime ReportDate,
    decimal TotalSales,
    decimal TotalExpenses,
    ICollection<InventoryResponse> Inventories,
    ICollection<SaleResponse> Sales);