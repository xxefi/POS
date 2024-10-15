using POS.Domain.Enums;

namespace POS.Domain.Entities;

public class PaymentEntity
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public Guid CustomerId { get; set; }
    public decimal Amount { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public OrderEntity Order { get; set; }
    public ICollection<CustomerEntity> Customer { get; set; } = [];
}
