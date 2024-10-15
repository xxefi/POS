namespace POS.API.Contracts.Report;

public record ReportRequest(
    DateTime ReportDate,
    string ReportType,
    string Content,
    string Title);