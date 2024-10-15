using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Domain.Abstractions.Repositories;

public interface ITerminalRepository : IGenericRepository<Terminal, TerminalEntity>
{
    Task<ICollection<Terminal>> GetByLocationAsync(string location);
    Task<Terminal?> GetByTerminalIdAsync(Guid terminalId);
}