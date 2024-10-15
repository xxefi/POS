namespace POS.API.Contracts.Feedback;

public record FeedbackRequest(
    string Comment,
    int Rating,
    Guid CustomerId);