using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Services;

public interface IFeedBackService
{
    Task<ICollection<Feedback>> GetAllFeedbacksAsync();
    Task<Feedback> GetFeedbackByIdAsync(Guid feedbackId);
    Task<ICollection<Feedback>> GetByCustomerIdAsync(Guid customerId);
    Task AddFeedbackAsync(FeedbackEntity feedback);
    Task UpdateFeedbackAsync(Feedback feedback);
    Task RemoveFeedbackAsync(Guid feedbackId);
}