using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Repositories;

public interface IOrderItemRepository : IGenericRepository<OrderItem, OrderItemEntity>
{
    Task<ICollection<OrderItem>> GetItemsByOrderIdAsync(Guid orderId);
}
