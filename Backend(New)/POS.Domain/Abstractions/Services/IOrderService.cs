using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Services;

public interface IOrderService
{
    Task<ICollection<Order>> GetAllOrdersAsync();
    Task<Order> GetOrderByIdAsync(Guid orderId);
    Task AddOrderAsync(OrderEntity order);
    Task UpdateOrderAsync(Order order);
    Task RemoveOrderAsync(Guid orderId);
}