
using Microsoft.EntityFrameworkCore;
using POS.Application.Exceptions;
using POS.Domain.Abstractions.Repositories;
using POS.Domain.Entities;
using POS.Domain.Models;
using POS.Infrastructure.Context;
using System.Linq.Expressions;

namespace POS.Infrastructure.Repositories;

public class FeedBackRepository : IFeedBackRepository
{
    private readonly POSContext _context;

    public FeedBackRepository(POSContext context)
        => _context = context;

    private static Feedback CreateFeedBackDB(FeedbackEntity feedbackEntity)
    {
        var result = Feedback.Create(feedbackEntity.Id, feedbackEntity.Comment, feedbackEntity.Rating);

        if (!string.IsNullOrEmpty(result.Errors)) throw new MyAuthException(AuthErrorTypes.InvalidRequest, result.Errors);
        return result.Feedback;
     }
    public async Task AddAsync(FeedbackEntity model)
    {
        var (feedback, error) = Feedback.Create(model.Id, model.Comment, model.Rating);

        if (!string.IsNullOrEmpty(error)) throw new MyAuthException(AuthErrorTypes.InvalidRequest, error);

        var feedBackEntity = new FeedbackEntity
        {
            Comment = feedback.Comment,
            Rating = feedback.Rating,
        };

        await _context.Feedbacks.AddAsync(feedBackEntity);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Feedback>> FindAsync(Expression<Func<FeedbackEntity, bool>> predicate)
    {
        var feedBackEntity = await _context.Feedbacks
            .AsNoTracking()
            .Where(predicate)
            .ToListAsync();

        return feedBackEntity
            .Select(CreateFeedBackDB)
            .ToList();
    }

    public async Task<ICollection<Feedback>> GetAllAsync()
    {
        var feedBackEntity = await _context.Feedbacks
            .AsNoTracking()
            .ToListAsync();

        if (!feedBackEntity.Any()) throw new MyAuthException(AuthErrorTypes.NotFound, "No feedbacks found");

        return feedBackEntity
            .Select(CreateFeedBackDB)
            .ToList();
    }

    public async Task<ICollection<Feedback>> GetByCustomerIdAsync(Guid customerId)
    {
        var feedbackEntities = await _context.Feedbacks
            .AsNoTracking()
            .Where(f => f.CustomerId == customerId)
            .ToListAsync();

        return feedbackEntities
            .Select(CreateFeedBackDB)
            .ToList();
    }

    public async Task<Feedback> GetByIdAsync(Guid id)
    {
        var feedbackEntity = await _context.Feedbacks
            .AsNoTracking()
            .FirstOrDefaultAsync(f => f.Id == id)
            ?? throw new MyAuthException(AuthErrorTypes.NotFound, "Feedback not found");

        return CreateFeedBackDB(feedbackEntity);
    }

    public async Task Remove(Feedback model)
    {
        var feedbackEntity = await _context.Feedbacks
            .FirstOrDefaultAsync(f => f.Id == model.Id)
            ?? throw new MyAuthException(AuthErrorTypes.NotFound, "Feedback not found");

        _context.Feedbacks.Remove(feedbackEntity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Feedback model)
    {
        var feedbackEntity = await _context.Feedbacks
            .FirstOrDefaultAsync(f => f.Id == model.Id)
            ?? throw new MyAuthException(AuthErrorTypes.NotFound, "Feedback not found");

        feedbackEntity.Comment = model.Comment;
        feedbackEntity.Rating = model.Rating;

        _context.Feedbacks.Update(feedbackEntity);
        await _context.SaveChangesAsync();
    }
}
