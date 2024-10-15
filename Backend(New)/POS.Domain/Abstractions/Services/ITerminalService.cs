using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Services;

public interface ITerminalService
{
    Task<ICollection<Terminal>> GetAllTerminalsAsync();
    Task<Terminal> GetTerminalByIdAsync(Guid terminalId);
    Task AddTerminalAsync(TerminalEntity terminal);
    Task UpdateTerminalAsync(Terminal terminal);
    Task RemoveTerminalAsync(Guid terminalId);
}