using POS.Domain.Abstractions.Repositories;
using POS.Domain.Abstractions.Services;
using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Application.Services;

public class TableService : ITableService
{
    private readonly ITableRepository _tableRepository;

    public TableService(ITableRepository tableRepository)
    {
        _tableRepository = tableRepository;
    }
    public async Task<ICollection<Table>> GetAllTablesAsync()
    {
        return await _tableRepository.GetAllAsync();
    }

    public async Task<Table> GetTableByIdAsync(Guid tableId)
    {
        return await _tableRepository.GetByIdAsync(tableId);
    }

    public async Task AddTableAsync(TableEntity table)
    {
        await _tableRepository.AddAsync(table);
    }

    public async Task UpdateTableAsync(Table table)
    {
        var existingTable = await _tableRepository.GetByIdAsync(table.Id);
        await _tableRepository.Update(existingTable);
    }

    public async Task RemoveTableAsync(Guid tableId)
    {
        var existingTable = await _tableRepository.GetByIdAsync(tableId);
        await _tableRepository.Remove(existingTable);
    }

    public async Task<ICollection<Table>> GetAvailableTablesAsync()
    {
        return await _tableRepository.GetAvailableTablesAsync();
    }
}