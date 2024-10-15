
using POS.Domain.Abstractions.Repositories;
using POS.Domain.Entities;
using POS.Domain.Enums;
using POS.Domain.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using POS.Application.Exceptions;
using POS.Infrastructure.Context;

namespace POS.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{ 
    private readonly POSContext _context;

    public OrderRepository(POSContext context)
        => _context = context;
    
    private static Order CreateOrderDB(OrderEntity entity)
    {
        var result = Order.Create(entity.Id, entity.CreatedAt, entity.TableId, entity.TotalAmount, entity.Status);

        if (!string.IsNullOrEmpty(result.Errors)) throw new MyAuthException(AuthErrorTypes.InvalidRequest, result.Errors);
        return result.Order;
    }

    public async Task AddAsync(OrderEntity model)
    {
        var (order, error) = Order.Create(model.Id, model.CreatedAt, model.TableId, model.TotalAmount, model.Status);

        if (!string.IsNullOrEmpty(error)) throw new MyAuthException(AuthErrorTypes.InvalidRequest, error);

        var entity = new OrderEntity
        {
            TableId = order.TableId,
            TotalAmount = order.TotalAmount,
            Status = order.Status,
            CreatedAt = order.CreatedAt
        };

        await _context.Orders.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Order>> FindAsync(Expression<Func<OrderEntity, bool>> predicate)
    {
        var entities = await _context.Orders
            .AsNoTracking()
            .Where(predicate)
            .ToListAsync();

        return entities
            .Select(CreateOrderDB)
            .ToList();
    }

    public async Task<ICollection<Order>> GetAllAsync()
    {
        var entities = await _context.Orders
            .AsNoTracking()
            .ToListAsync();
        
        if (!entities.Any()) throw new MyAuthException(AuthErrorTypes.NotFound, "No orders found");

        return entities
            .Select(CreateOrderDB)
            .ToList();
    }

    public async Task<Order> GetByIdAsync(Guid id)
    {
        var entity = await _context.Orders
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Id == id)
                ?? throw new MyAuthException(AuthErrorTypes.NotFound,"Order not found");

            return CreateOrderDB(entity);
    }

    public async Task<ICollection<Order>> GetByTableIdAsync(Guid tableId)
    {
        var entities = await _context.Orders
            .AsNoTracking()
            .Where(o => o.TableId == tableId)
            .ToListAsync();

        return entities
            .Select(CreateOrderDB)
            .ToList();
    }

    public async Task<ICollection<Order>> GetOrdersByDateAsync(DateTime date)
    {
        var entities = await _context.Orders
            .AsNoTracking()
            .Where(o => o.CreatedAt.Date == date.Date)
            .ToListAsync();

        return entities
            .Select(CreateOrderDB)
            .ToList();
    }

    public async Task<ICollection<Order>> GetOrdersByStatusAsync(OrderStatus status)
    {
        var entities = await _context.Orders
            .AsNoTracking()
            .Where(o => o.Status == status)
            .ToListAsync();

        return entities
            .Select(CreateOrderDB)
            .ToList();
    }

    public async Task Remove(Order model)
    {
        var entity = await _context.Orders.FindAsync(model.Id)
                     ?? throw new MyAuthException(AuthErrorTypes.NotFound,"Order not found");

        _context.Orders.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Order model)
    {
        var entity = await _context.Orders.FindAsync(model.Id)
                     ?? throw new MyAuthException(AuthErrorTypes.NotFound,"Order not found");

        entity.TableId = model.TableId;
        entity.TotalAmount = model.TotalAmount;
        entity.Status = model.Status;

        await _context.SaveChangesAsync();
    }
}
