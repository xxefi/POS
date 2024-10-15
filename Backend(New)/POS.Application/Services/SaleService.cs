using POS.Domain.Abstractions.Repositories;
using POS.Domain.Abstractions.Services;
using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Application.Services;

public class SaleService : ISaleService
{
    private readonly ISaleRepository _saleRepository;

    public SaleService(ISaleRepository saleRepository)
        => _saleRepository = saleRepository;
    
    public async Task<ICollection<Sale>> GetAllSalesAsync()
    {
        return await _saleRepository.GetAllAsync();
    }

    public async Task<Sale> GetSaleByIdAsync(Guid saleId)
    {
        return await _saleRepository.GetByIdAsync(saleId);
    }

    public async Task AddSaleAsync(SaleEntity sale)
    {
        await _saleRepository.AddAsync(sale);
    }

    public async Task UpdateSaleAsync(Sale sale)
    {
        var existingSale = await _saleRepository.GetByIdAsync(sale.Id);
        await _saleRepository.Update(existingSale);
    }

    public async Task RemoveSaleAsync(Guid saleId)
    {
        var existingSale = await _saleRepository.GetByIdAsync(saleId);
        await _saleRepository.Remove(existingSale);
    }
}