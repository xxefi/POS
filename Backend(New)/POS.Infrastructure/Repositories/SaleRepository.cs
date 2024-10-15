using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using POS.Application.Exceptions;
using POS.Domain.Abstractions.Repositories;
using POS.Domain.Entities;
using POS.Domain.Models;
using POS.Infrastructure.Context;

namespace POS.Infrastructure.Repositories;

public class SaleRepository : ISaleRepository
{
    private readonly POSContext _context;

    public SaleRepository(POSContext context)
        => _context = context;
    
    private static Sale CreateSaleDB(SaleEntity entity)
    {
        var result = Sale.Create(entity.Id, entity.SaleDate, entity.TotalAmount);

        if (!string.IsNullOrEmpty(result.Errors)) throw new InvalidOperationException(result.Errors);
        return result.Sale;
    }
    
    public async Task<Sale> GetByIdAsync(Guid id)
        {
            var entity = await _context.Sales
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id)
                ?? throw new MyAuthException(AuthErrorTypes.NotFound,"Sale not found");

            return CreateSaleDB(entity);
        }

    public async Task<ICollection<Sale>> GetAllAsync()
    {
        var entities = await _context.Sales
            .AsNoTracking()
            .ToListAsync();
        
        if (!entities.Any()) throw new MyAuthException(AuthErrorTypes.NotFound, "No sale found");

        return entities
            .Select(CreateSaleDB)
            .ToList();
    }

    public async Task AddAsync(SaleEntity model)
    {
        var (sale, error) = Sale.Create(model.Id, model.SaleDate, model.TotalAmount);

        if (!string.IsNullOrEmpty(error)) throw new MyAuthException(AuthErrorTypes.InvalidRequest, error);

        var entity = new SaleEntity
        {
            SaleDate = sale.SaleDate,
            TotalAmount = sale.TotalAmount
        };

        await _context.Sales.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Remove(Sale model)
    {
            var entity = await _context.Sales.FindAsync(model.Id)
                ?? throw new MyAuthException(AuthErrorTypes.NotFound,"Sale not found");

            _context.Sales.Remove(entity);
            await _context.SaveChangesAsync();
    }

    public async Task Update(Sale model)
    {
        var entity = await _context.Sales.FindAsync(model.Id)
                ?? throw new MyAuthException(AuthErrorTypes.NotFound,"Sale not found");
        
        entity.TotalAmount = model.TotalAmount;
        entity.SaleDate = model.SaleDate;
    }

    public async Task<ICollection<Sale>> FindAsync(Expression<Func<SaleEntity, bool>> predicate)
    {
        var entities = await _context.Sales
            .AsNoTracking()
            .Where(predicate)
            .ToListAsync();

        return entities
            .Select(CreateSaleDB)
            .ToList();
    }

    public async Task<ICollection<Sale>> GetSalesByDateAsync(DateTime date)
    {
        var entities = await _context.Sales
            .AsNoTracking()
            .Where(s => s.SaleDate.Date == date.Date)
            .ToListAsync();

        return entities
            .Select(CreateSaleDB)
            .ToList();
    }

    public async Task<ICollection<Sale>> GetSalesByCustomerIdAsync(Guid customerId)
    {
        var entities = await _context.Sales
            .AsNoTracking()
            .Where(s => s.CustomerId == customerId)
            .ToListAsync();

        return entities
            .Select(CreateSaleDB)
            .ToList();
    }
}