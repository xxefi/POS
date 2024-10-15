using POS.Domain.Abstractions.Repositories;
using POS.Domain.Abstractions.Services;
using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Application.Services;

public class CashierService : ICashierService
{
    private readonly ICashierRepository _cashierRepository;

    public CashierService(ICashierRepository cashierRepository)
        => _cashierRepository = cashierRepository;
    
    public async Task<ICollection<Cashier>> GetAllCashiersAsync()
    {
        return await _cashierRepository.GetAllAsync();
    }

    public async Task<Cashier> GetCashierByIdAsync(Guid cashierId)
    {
        return await _cashierRepository.GetByIdAsync(cashierId);
    }

    public async Task AddCashierAsync(CashierEntity cashier)
        =>  await _cashierRepository.AddAsync(cashier);

    public async Task UpdateCashierAsync(Cashier cashier)
    {
        var existingCashier = await _cashierRepository.GetByIdAsync(cashier.Id);
        await _cashierRepository.Update(existingCashier);    
    }

    public async Task RemoveCashierAsync(Guid cashierId)
    {
        var cashier = await _cashierRepository.GetByIdAsync(cashierId);
        await _cashierRepository.Remove(cashier);
    }
}