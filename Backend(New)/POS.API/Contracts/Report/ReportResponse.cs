namespace POS.API.Contracts.Report;

public record ReportResponse(
    Guid Id,
    DateTime ReportDate,
    string ReportType,
    string Content,
    string Title);