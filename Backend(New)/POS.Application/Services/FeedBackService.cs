using POS.Domain.Abstractions.Repositories;
using POS.Domain.Abstractions.Services;
using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Application.Services;

public class FeedBackService : IFeedBackService
{
    private readonly IFeedBackRepository _feedBackRepository;

    public FeedBackService(IFeedBackRepository feedBackRepository)
        => _feedBackRepository = feedBackRepository;
    
    public async Task<ICollection<Feedback>> GetAllFeedbacksAsync()
    {
        return await _feedBackRepository.GetAllAsync();
    }

    public async Task<Feedback> GetFeedbackByIdAsync(Guid feedbackId)
    {
        return await _feedBackRepository.GetByIdAsync(feedbackId);
    }

    public async Task<ICollection<Feedback>> GetByCustomerIdAsync(Guid customerId)
    {
        return await _feedBackRepository.GetByCustomerIdAsync(customerId);
    }

    public async Task AddFeedbackAsync(FeedbackEntity feedback)
    {
        await _feedBackRepository.AddAsync(feedback);
    }

    public async Task UpdateFeedbackAsync(Feedback feedback)
    {
        var existingFeedback = await _feedBackRepository.GetByIdAsync(feedback.Id);
        await _feedBackRepository.Update(existingFeedback);
    }

    public async Task RemoveFeedbackAsync(Guid feedbackId)
    {
        var existingFeedback = await _feedBackRepository.GetByIdAsync(feedbackId);
        await _feedBackRepository.Remove(existingFeedback);
    }
}