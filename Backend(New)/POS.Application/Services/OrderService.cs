using POS.Domain.Abstractions.Repositories;
using POS.Domain.Abstractions.Services;
using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Application.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
        => _orderRepository = orderRepository;
    
    public async Task<ICollection<Order>> GetAllOrdersAsync()
    {
        return await _orderRepository.GetAllAsync();
    }

    public async Task<Order> GetOrderByIdAsync(Guid orderId)
    {
        return await _orderRepository.GetByIdAsync(orderId);
    }

    public async Task AddOrderAsync(OrderEntity order)
    {
        await _orderRepository.AddAsync(order);
    }

    public async Task UpdateOrderAsync(Order order)
    {
        var existingOrder = await _orderRepository.GetByIdAsync(order.Id);
        await _orderRepository.Update(existingOrder);
    }

    public async Task RemoveOrderAsync(Guid orderId)
    {
        var existingOrder = await _orderRepository.GetByIdAsync(orderId);
        await _orderRepository.Remove(existingOrder);
    }
}