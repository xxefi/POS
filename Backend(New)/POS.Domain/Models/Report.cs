namespace POS.Domain.Models;

public class Report
{
    private Report(Guid id, DateTime reportDate, string reportType, string content, string title)
    {
        Id = id;
        ReportDate = reportDate;
        ReportType = reportType;
        Content = content;
        Title = title;
    }

    public Guid Id { get; }
    public DateTime ReportDate { get; }
    public string ReportType { get; }
    public string Content { get; }
    public string Title { get; }

    public static (Report Report, string Errors) Create(Guid id, DateTime reportDate, string reportType, string content, string title)
    {
        var errors = new List<string>
        {
            reportDate > DateTime.UtcNow ? "Report date cannot be in the future" : null,
            string.IsNullOrWhiteSpace(reportType) ? "Report type cannot be empty" : null,
            string.IsNullOrWhiteSpace(content) ? "Content cannot be empty" : null,
            string.IsNullOrWhiteSpace(title) ? "Title cannot be empty" : null
        }.Where(e => e != null).ToList();

        var report = new Report(id, reportDate, reportType, content, title);
        return (report, errors.Count > 0 ? string.Join("\n", errors) : string.Empty);
    }
}