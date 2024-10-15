namespace POS.Domain.Entities;

public class CustomerEntity
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public ICollection<FeedbackEntity> Feedbacks { get; set; } = [];
    public Guid SaleId { get; set; }    
    public ICollection< SaleEntity> Sales { get; set; }
}
