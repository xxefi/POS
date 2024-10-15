using POS.Domain.Entities;
using POS.Domain.Enums;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Repositories;

public interface IOrderRepository : IGenericRepository<Order, OrderEntity>
{
    Task<ICollection<Order>> GetByTableIdAsync(Guid tableId);
    Task<ICollection<Order>> GetOrdersByStatusAsync(OrderStatus status);
    Task<ICollection<Order>> GetOrdersByDateAsync(DateTime date);
}
