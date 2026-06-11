namespace TEMPO.Contracts.Dtos;

public record ReportResponse
{
    public Guid Id { get; init; }
    public IEnumerable<TimeEntryResponse> TimeEntries { get; init; } = [];
    public required string Status { get; init; }
    public string? SubmittedAt { get; init; }
    public string? VerifiedAt { get; init; }
    public string? RejectedAt { get; init; }
    public string? SentAt { get; init; }
    public string? FeedBack { get; init; }
    public string? ReviewedBy { get; init; }
}