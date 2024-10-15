using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Repositories;

public interface IFeedBackRepository : IGenericRepository<Feedback, FeedbackEntity>
{
    Task<ICollection<Feedback>> GetByCustomerIdAsync(Guid customerId);
}