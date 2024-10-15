namespace POS.Domain.Entities;

public class FeedbackEntity
{
    public Guid Id { get; set; }
    public string Comment { get; set; } = string.Empty;
    public int Rating { get; set; } 
    public Guid CustomerId { get; set; }
    public CustomerEntity? Customer { get; set; }
}
