namespace POS.Domain.Entities;

public class CashierEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string PinCode { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
}
