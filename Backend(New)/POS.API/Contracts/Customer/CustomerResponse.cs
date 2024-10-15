using POS.API.Contracts.Feedback;
using POS.API.Contracts.Sale;

namespace POS.API.Contracts.Customer;

public record CustomerResponse(
    Guid Id,
    string FullName,
    string Email,
    string PhoneNumber,
    ICollection<FeedbackResponse> Feedbacks,
    ICollection<SaleResponse> Sales);