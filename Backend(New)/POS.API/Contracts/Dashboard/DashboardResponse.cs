namespace POS.API.Contracts.Dashboard;

public record DashboardResponse(
    Guid Id,
    DateTime DateGenerated,
    decimal TotalSales,
    decimal TotalRevenue,
    string Title,
    string Description);