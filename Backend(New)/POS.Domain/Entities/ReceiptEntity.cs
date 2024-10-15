namespace POS.Domain.Entities;

public class ReceiptEntity
{
    public Guid Id { get; set; }
    public DateTime DateIssued { get; set; }
    public decimal TotalAmount { get; set; }
    public Guid SaleId { get; set; }
    public SaleEntity? Sale { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid OrderId { get; set; }
    public OrderEntity? Order { get; set; }
}
