namespace POS.Domain.Models;

public class Statistics
{
    private Statistics(Guid id, DateTime reportDate, decimal totalSales, decimal totalExpenses)
    {
        Id = id;
        ReportDate = reportDate;
        TotalSales = totalSales;
        TotalExpenses = totalExpenses;
    }

    public Guid Id { get; }
    public DateTime ReportDate { get; }
    public decimal TotalSales { get; }
    public decimal TotalExpenses { get; }

    public static (Statistics Statistics, string Errors) Create(Guid id, DateTime reportDate, decimal totalSales, decimal totalExpenses)
    {
        var errors = new List<string>
        {
            reportDate > DateTime.UtcNow ? "Report date cannot be in the future" : null,
            totalSales < 0 ? "Total sales cannot be negative" : null,
            totalExpenses < 0 ? "Total expenses cannot be negative" : null
        }.Where(e => e != null).ToList();

        var statistics = new Statistics(id, reportDate, totalSales, totalExpenses);
        return (statistics, errors.Count > 0 ? string.Join("\n", errors) : string.Empty);
    }
}