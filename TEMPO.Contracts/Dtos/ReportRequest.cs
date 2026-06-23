namespace TEMPO.Contracts.Dtos;

public record GetReportRequest
{
    public required DateOnly Date { get; init; }
}

public record ReportRequest
{
    public string? Id { get; init; }
    public string? UserId { get; init; }
    public DateOnly WeekStart { get; init; }
    public required IEnumerable<CreateTimeEntryRequest> TimeEntries { get; init; }
    public string? Status { get; init; }
    public string? SubmittedAt { get; init; }
    public string? VerifiedAt { get; init; }
    public string? RejectedAt { get; init; }
    public string? SentAt { get; init; }
    public string? Feedback { get; init; }
    public string? ReviewedBy { get; init; }
}