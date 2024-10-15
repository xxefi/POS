using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Services;

public interface ISaleService
{
    Task<ICollection<Sale>> GetAllSalesAsync();
    Task<Sale> GetSaleByIdAsync(Guid saleId);
    Task AddSaleAsync(SaleEntity sale);
    Task UpdateSaleAsync(Sale sale);
    Task RemoveSaleAsync(Guid saleId);
}