namespace POS.API.Contracts.Statistics;

public record StatisticsRequest(
    DateTime ReportDate,
    decimal TotalSales,
    decimal TotalExpenses);