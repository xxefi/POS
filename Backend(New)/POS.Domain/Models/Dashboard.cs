namespace POS.Domain.Models;

public class Dashboard
{
    private Dashboard(Guid id, DateTime dateGenerated, decimal totalSales, decimal totalRevenue, string title, string description)
    {
        Id = id;
        DateGenerated = dateGenerated;
        TotalSales = totalSales;
        TotalRevenue = totalRevenue;
        Title = title;
        Description = description;
    }

    public Guid Id { get; }
    public DateTime DateGenerated { get; }
    public decimal TotalSales { get; }
    public decimal TotalRevenue { get; }
    public string Title { get; }
    public string Description { get; }
    
    public static (Dashboard Dashboard, string Errors) Create(Guid id, DateTime dateGenerated, decimal totalSales, decimal totalRevenue, string title, string description)
    {
        var errors = new List<string>
        {
            dateGenerated > DateTime.UtcNow ? "Date generated cannot be in the future" : null,
            totalSales < 0 ? "Total sales cannot be negative" : null,
            totalRevenue < 0 ? "Total revenue cannot be negative" : null,
            string.IsNullOrWhiteSpace(title) ? "Title cannot be empty" : null,
            string.IsNullOrWhiteSpace(description) ? "Description cannot be empty" : null
        }.Where(e => e != null).ToList();
        
        var dashboard = new Dashboard(id, dateGenerated, totalSales, totalRevenue, title, description);
        return (dashboard, errors.Count > 0 ? string.Join("\n", errors) : string.Empty);
    }
}