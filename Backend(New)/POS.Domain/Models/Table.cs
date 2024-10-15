namespace POS.Domain.Models;

public class Table
{
    private Table(Guid id, int number, bool isBusy)
    {
        Id = id;
        Number = number;
        IsBusy = isBusy;
    }

    public Guid Id { get; }
    public int Number { get; }
    public bool IsBusy { get; }

    public static (Table Table, string Errors) Create(Guid id, int number, bool isBusy)
    {
        var error = string.Empty;

        if (number <= 0)
            error = "Table number must be greater than 0";
            
        var table = new Table(id, number, isBusy);
        return (table, error);
    }
}