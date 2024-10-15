using POS.API.Contracts.TerminalSettings;

namespace POS.API.Contracts.Terminal;

public record TerminalResponse(
    Guid Id,
    string TerminalName,
    string Location,
    ICollection<TerminalSettingsResponse> Settings);