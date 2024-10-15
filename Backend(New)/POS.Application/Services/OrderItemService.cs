using POS.Domain.Abstractions.Repositories;
using POS.Domain.Abstractions.Services;
using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Application.Services;

public class OrderItemService : IOrderItemService
{
    private readonly IOrderItemRepository _orderItemRepository;

    public OrderItemService(IOrderItemRepository orderItemRepository)
        => _orderItemRepository = orderItemRepository;
    
    public async Task<ICollection<OrderItem>> GetAllOrderItemsAsync()
    {
        return await _orderItemRepository.GetAllAsync();
    }

    public async Task<OrderItem> GetOrderItemByIdAsync(Guid orderItemId)
    {
        return await _orderItemRepository.GetByIdAsync(orderItemId);
    }

    public async Task AddOrderItemAsync(OrderItemEntity orderItem)
    {
        await _orderItemRepository.AddAsync(orderItem);
    }

    public async Task UpdateOrderItemAsync(OrderItem orderItem)
    {
        var existingOrderItem = await _orderItemRepository.GetByIdAsync(orderItem.Id);
        await _orderItemRepository.Update(existingOrderItem);
    }

    public async Task RemoveOrderItemAsync(Guid orderItemId)
    {
        var existingOrderItem = await _orderItemRepository.GetByIdAsync(orderItemId);
        await _orderItemRepository.Remove(existingOrderItem);
    }
}