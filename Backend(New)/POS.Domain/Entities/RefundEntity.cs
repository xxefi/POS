namespace POS.Domain.Entities;

public class RefundEntity
{
    public Guid Id { get; set; }
    public DateTime RefundDate { get; set; }
    public decimal Amount { get; set; }
    public Guid SaleId { get; set; }
    public SaleEntity? Sale { get; set; }
    public Guid OrderId { get; set; }
    public OrderEntity? Order { get; set; }
    public DateTime CreatedAt { get; set; }
}
