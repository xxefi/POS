namespace POS.Domain.Entities;

public class StatisticsEntity
{
    public Guid Id { get; set; }
    public DateTime ReportDate { get; set; }
    public decimal TotalSales { get; set; }
    public decimal TotalExpenses { get; set; }
    public ICollection<InventoryEntity> Inventories {get; set;} = [];
    public ICollection<SaleEntity> Sales {get; set;} = [];
}