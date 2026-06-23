using TEMPO.Contracts.Dtos;

namespace TEMPO.Service.Command;

public record GetReportCommand
{
    public required string UserId { get; init; }
    public required DateOnly Date { get; init; }
}

public record ReportRequestCommand
{
    public string? Id { get; init; }
    public string? UserId { get; init; }
    public DateOnly WeekStart { get; init; }
    public required IEnumerable<CreateTimeEntryCommand> TimeEntries { get; init; }
    public string? Status { get; init; }
    public string? SubmittedAt { get; init; }
    public string? VerifiedAt { get; init; }
    public string? RejectedAt { get; init; }
    public string? SentAt { get; init; }
    public string? Feedback { get; init; }
    public string? ReviewedBy { get; init; }
}

// public required string EmployeeId { get; init; }
// public DateOnly WeekStart { get; init; }
// public ICollection<TimeEntry> TimeEntry { get; init; } = new List<TimeEntry>();
// public required string Status { get; init; }
// public string? SubmittedAt { get; init; }
// public string? VerifiedAt { get; init; }
// public string? RejectedAt { get; init; }
// public string? SentAt { get; init; }
// public string? FeedBack { get; init; }
// public string? ReviewedBy { get; init; }