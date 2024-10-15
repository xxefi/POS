namespace POS.Domain.Entities;

public class TableEntity
{
    public Guid Id { get; set; }
    public int Number { get; set; }
    public bool IsBusy { get; set; }
    public ICollection<OrderEntity> Orders { get; set; } = [];
}
