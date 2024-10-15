
using Microsoft.EntityFrameworkCore;
using POS.Application.Exceptions;
using POS.Domain.Abstractions.Repositories;
using POS.Domain.Entities;
using POS.Domain.Models;
using POS.Infrastructure.Context;
using System.Linq.Expressions;
using static BCrypt.Net.BCrypt;

namespace POS.Infrastructure.Repositories;

public class CashierRepository : ICashierRepository
{
    private readonly POSContext _context;

    public CashierRepository(POSContext context)
        => _context = context;
    private static Cashier CreateCashierDB(CashierEntity cashierEntity)
    {
        var result = Cashier.Create(cashierEntity.Id, cashierEntity.Name, cashierEntity.Email, cashierEntity.Phone,
            cashierEntity.PinCode, cashierEntity.Brand);

        if (!string.IsNullOrEmpty(result.Errors)) throw new MyAuthException(AuthErrorTypes.InvalidRequest, result.Errors);
        return result.Cashier;
    }
    public async Task AddAsync(CashierEntity model)
    {
        var (cashier, error) = Cashier.Create(
            model.Id,
            model.Name,
            model.Email,
            model.Phone,
            model.PinCode,
            model.Brand);

        if (!string.IsNullOrEmpty(error)) throw new MyAuthException(AuthErrorTypes.InvalidRequest, error);
        
        var existingCashier = await _context.Cashiers
            .AsNoTracking()
            .AnyAsync(c => c.Email == cashier.Email || c.Phone == cashier.Phone);
        
        if (existingCashier) throw new MyAuthException(AuthErrorTypes.CredentialsAlreadyExists, "Email and phone already exists");

        var cashierEntity = new CashierEntity
        {
            Email = cashier.Email,
            Brand = cashier.Brand,
            Name = cashier.Name,
            Phone = cashier.Phone,
            PinCode = HashPassword(cashier.PinCode),
        };
        await _context.Cashiers.AddAsync(cashierEntity);
        await _context.SaveChangesAsync();

    }

    public async Task<ICollection<Cashier>> FindAsync(Expression<Func<CashierEntity, bool>> predicate)
    {
        var cashiers = await _context.Cashiers
            .AsNoTracking()
            .Where(predicate)
            .ToListAsync();

        return cashiers
            .Select(CreateCashierDB)
            .ToList();
    }

    public async Task<ICollection<Cashier>> GetAllAsync()
    {
        var cashiers = await _context.Cashiers
            .AsNoTracking()
            .ToListAsync();
        
        if (!cashiers.Any()) throw new MyAuthException(AuthErrorTypes.NotFound, "Cashiers not found");

        return cashiers
            .Select(CreateCashierDB)
            .ToList();
    }

    public async Task<Cashier?> GetByEmailAsync(string email)
    {
        var cashierEntity = await _context.Cashiers
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Email == email);

        return cashierEntity != null
            ? CreateCashierDB(cashierEntity)
            : throw new MyAuthException(AuthErrorTypes.NotFound, "Cashier not found");
    }

    public async Task<Cashier> GetByIdAsync(Guid id)
    {
        var cashierEntity = await _context.Cashiers
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id)
            ?? throw new MyAuthException(AuthErrorTypes.NotFound, "Cashier not found");

        return CreateCashierDB(cashierEntity);
    }

    public async Task<Cashier?> GetByPhoneNumberAsync(string phoneNumber)
    {
        var cashierEntity = await _context.Cashiers
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Phone == phoneNumber)
            ?? throw new MyAuthException(AuthErrorTypes.NotFound, "Cashier not found");

        return CreateCashierDB(cashierEntity);

    }

    public async Task Remove(Cashier model)
    {
        var cashierEntity = await _context.Cashiers.FindAsync(model.Id)
            ?? throw new MyAuthException(AuthErrorTypes.NotFound, "Cashier not found");

        _context.Cashiers.Remove(cashierEntity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Cashier model)
    {
        var cashierEntity = await _context.Cashiers.FindAsync(model.Id)
            ?? throw new MyAuthException(AuthErrorTypes.NotFound, "Cashier not found");

        cashierEntity.Name = model.Name;
        cashierEntity.Email = model.Email;
        cashierEntity.Phone = model.Phone;
        cashierEntity.PinCode = HashPassword(model.PinCode);
        cashierEntity.Brand = model.Brand;

        await _context.SaveChangesAsync();
    }
}
