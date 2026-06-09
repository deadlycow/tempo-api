namespace TEMPO.Data.Entities;

public class TimeEntry
{
    public Guid Id { get; set; }
    public required string EmployeeId { get; set; }
    public AppUser Employee { get; set; } = null!;
    public DateTime Date { get; set; }
    public double HoursWorked { get; set; }
    public string? Description { get; set; }
    public required Guid ProjectId { get; set; }
    public Project Project { get; set; } = null!;
    public Guid WeeklyReportId { get; set; }
    public WeeklyReport WeeklyReport { get; set; } = null!;
}

public class WeeklyReport
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string EmployeeId { get; set; }
    public AppUser Employee { get; set; } = null!;
    public DateOnly WeekStart { get; set; }
    public ICollection<TimeEntry> TimeEntry { get; set; } = new List<TimeEntry>();
    public required string Status { get; set; }
    public string? SubmittedAt { get; set; }
    public string? VerifiedAt { get; set; }
    public string? RejectedAt { get; set; }
    public string? SentAt { get; set; }
    public string? FeedBack { get; set; }
    public string? ReviewedBy { get; set; }
}