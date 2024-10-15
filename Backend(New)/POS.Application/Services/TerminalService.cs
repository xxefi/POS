using POS.Domain.Abstractions.Repositories;
using POS.Domain.Abstractions.Services;
using POS.Domain.Entities;
using POS.Domain.Models;

namespace POS.Application.Services;

public class TerminalService : ITerminalService
{
    private readonly ITerminalRepository _terminalRepository;

    public TerminalService(ITerminalRepository terminalRepository)
        => _terminalRepository = terminalRepository;
    
    public async Task<ICollection<Terminal>> GetAllTerminalsAsync()
    {
        return await _terminalRepository.GetAllAsync();
    }

    public async Task<Terminal> GetTerminalByIdAsync(Guid terminalId)
    {
        return await _terminalRepository.GetByIdAsync(terminalId);
    }

    public async Task AddTerminalAsync(TerminalEntity terminal)
    {
        await _terminalRepository.AddAsync(terminal);
    }

    public async Task UpdateTerminalAsync(Terminal terminal)
    {
        var existedTerminal = await _terminalRepository.GetByIdAsync(terminal.Id);
        await _terminalRepository.Update(existedTerminal);
    }

    public async Task RemoveTerminalAsync(Guid terminalId)
    {
        var existedTerminal = await _terminalRepository.GetByIdAsync(terminalId);
        await _terminalRepository.Remove(existedTerminal);
    }
}