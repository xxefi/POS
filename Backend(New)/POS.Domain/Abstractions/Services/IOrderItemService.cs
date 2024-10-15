using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Services;

public interface IOrderItemService
{
    Task<ICollection<OrderItem>> GetAllOrderItemsAsync();
    Task<OrderItem> GetOrderItemByIdAsync(Guid orderItemId);
    Task AddOrderItemAsync(OrderItemEntity orderItem);
    Task UpdateOrderItemAsync(OrderItem orderItem);
    Task RemoveOrderItemAsync(Guid orderItemId);
}