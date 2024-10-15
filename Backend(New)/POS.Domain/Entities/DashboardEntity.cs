namespace POS.Domain.Entities;

public class DashboardEntity
{
    public Guid Id { get; set; }
    public DateTime DateGenerated { get; set; }
    public decimal TotalSales { get; set; }
    public decimal TotalRevenue { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
