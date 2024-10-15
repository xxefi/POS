namespace POS.API.Contracts.Terminal;

public record TerminalRequest(
    string TerminalName,
    string Location);