
using Microsoft.EntityFrameworkCore;
using POS.Application.Exceptions;
using POS.Domain.Abstractions.Repositories;
using POS.Domain.Entities;
using POS.Domain.Models;
using POS.Infrastructure.Context;
using System.Linq.Expressions;

namespace POS.Infrastructure.Repositories;

public class OrderItemRepository : IOrderItemRepository
{
    private readonly POSContext _context;

    public OrderItemRepository(POSContext context)
        => _context = context;
    private static OrderItem CreateOrderItemDB(OrderItemEntity entity)
    {
        var result = OrderItem.Create(entity.Id, entity.ProductName, entity.Quantity, entity.Price);

        if (!string.IsNullOrEmpty(result.Errors)) throw new InvalidOperationException(result.Errors);
        return result.OrderItem;
    }

    public async Task AddAsync(OrderItemEntity model)
    {
        var (orderItem, error) = OrderItem.Create(model.Id, model.ProductName, model.Quantity, model.Price);

        if (!string.IsNullOrEmpty(error)) throw new MyAuthException(AuthErrorTypes.InvalidRequest, error);

        var entity = new OrderItemEntity
        {
            ProductName = orderItem.ProductName,
            Quantity = orderItem.Quantity,
            Price = orderItem.Price
        };

        await _context.OrderItems.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<OrderItem>> FindAsync(Expression<Func<OrderItemEntity, bool>> predicate)
    {
        var entities = await _context.OrderItems
            .AsNoTracking()
            .Where(predicate)
            .ToListAsync();

        return entities
            .Select(CreateOrderItemDB)
            .ToList();
    }

    public async Task<ICollection<OrderItem>> GetAllAsync()
    {
        var entities = await _context.OrderItems
            .AsNoTracking()
            .ToListAsync();
        
        if (!entities.Any()) throw new MyAuthException(AuthErrorTypes.NotFound, "No order items found");

        return entities
            .Select(CreateOrderItemDB)
            .ToList();
    }

    public async Task<OrderItem> GetByIdAsync(Guid id)
    {
        var entity = await _context.OrderItems
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.Id == id)
            ?? throw new MyAuthException(AuthErrorTypes.NotFound,"OrderItem not found");

        return CreateOrderItemDB(entity);
    }

    public async Task<ICollection<OrderItem>> GetItemsByOrderIdAsync(Guid orderId)
    {
        var entities = await _context.OrderItems
            .AsNoTracking()
            .Where(o => o.OrderId == orderId)
            .ToListAsync();

        return entities
            .Select(CreateOrderItemDB)
            .ToList();
    }

    public async Task Remove(OrderItem model)
    {
        var entity = await _context.OrderItems.FindAsync(model.Id)
            ?? throw new MyAuthException(AuthErrorTypes.NotFound, "OrderItem not found");

        _context.OrderItems.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(OrderItem model)
    {
        var entity = await _context.OrderItems.FindAsync(model.Id)
            ?? throw new MyAuthException(AuthErrorTypes.NotFound, "OrderItem not found");

        entity.ProductName = model.ProductName;
        entity.Quantity = model.Quantity;
        entity.Price = model.Price;

        await _context.SaveChangesAsync();
    }
}
