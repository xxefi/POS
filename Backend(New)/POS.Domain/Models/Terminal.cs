namespace POS.Domain.Models;

public class Terminal
{
    public const int MAX_TERMINAL_NAME_LENGTH = 100;
    public const int MAX_LOCATION_LENGTH = 200;
    
    private Terminal(Guid id, string terminalName, string location)
    {
        Id = id;
        TerminalName = terminalName;
        Location = location;
    }
    
    public Guid Id { get; }
    public string TerminalName { get; }
    public string Location { get; }
    
    public static (Terminal Terminal, string Errors) Create(Guid id, string terminalName, string location)
    {
        var errors = new List<string>
            {
                string.IsNullOrWhiteSpace(terminalName) || terminalName.Length > MAX_TERMINAL_NAME_LENGTH
                    ? $"Terminal name must be between 1 and {MAX_TERMINAL_NAME_LENGTH} characters"
                    : null,
                string.IsNullOrWhiteSpace(location) || location.Length > MAX_LOCATION_LENGTH
                    ? $"Location must be between 1 and {MAX_LOCATION_LENGTH} characters"
                    : null
            }
            .Where(e => e != null)
            .ToList();

        var terminal = new Terminal(id, terminalName, location);
        return (terminal, errors.Count > 0 ? string.Join("\n", errors) : string.Empty);
    }
}