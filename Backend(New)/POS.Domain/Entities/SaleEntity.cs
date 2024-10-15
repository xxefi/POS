namespace POS.Domain.Entities;

public class SaleEntity
{
    public Guid Id { get; set; }
    public DateTime SaleDate { get; set; }
    public decimal TotalAmount { get; set; }
    public Guid CustomerId { get; set; }
    public CustomerEntity? Customer { get; set; }
    public ICollection<CustomerEntity> Customers { get; set; } = [];
}
