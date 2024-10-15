using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Services;

public interface ITableService
{
    Task<ICollection<Table>> GetAllTablesAsync();
    Task<Table> GetTableByIdAsync(Guid tableId);
    Task AddTableAsync(TableEntity table);
    Task UpdateTableAsync(Table table);
    Task RemoveTableAsync(Guid tableId);
    Task<ICollection<Table>> GetAvailableTablesAsync();
}