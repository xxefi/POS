namespace POS.API.Contracts.Feedback;

public record FeedbackResponse(
    Guid Id,
    string Comment,
    int Rating,
    Guid CustomerId);