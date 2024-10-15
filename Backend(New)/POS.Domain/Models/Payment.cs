using POS.Domain.Enums;

namespace POS.Domain.Models;

public class Payment
{
    private Payment(Guid id, Guid orderId, Guid customerId, decimal amount, PaymentMethod paymentMethod)
    {
        Id = id;
        OrderId = orderId;
        CustomerId = customerId;
        Amount = amount;
        PaymentMethod = paymentMethod;
    }

    public Guid Id { get; }
    public Guid OrderId { get; }
    public Guid CustomerId { get; }
    public decimal Amount { get; }
    public PaymentMethod PaymentMethod { get; }

    public static (Payment Payment, string Errors) Create(Guid id, Guid orderId, Guid customerId, decimal amount, PaymentMethod paymentMethod)
    {
        var errors = new List<string>
            {
                amount <= 0 ? "Amount must be greater than 0" : null,
                !Enum.IsDefined(typeof(PaymentMethod), paymentMethod) ? "Invalid payment method" : null
            }
            .Where(e => e != null)
            .ToList();

        var payment = new Payment(id, orderId, customerId, amount, paymentMethod);
        return (payment, errors.Count > 0 ? string.Join("\n", errors) : string.Empty);
    }
}