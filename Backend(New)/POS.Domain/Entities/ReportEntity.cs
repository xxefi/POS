namespace POS.Domain.Entities;

public class ReportEntity
{
    public Guid Id { get; set; }
    public DateTime ReportDate { get; set; }
    public string ReportType { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
}
