namespace TEMPO.Data.Entities;

public class Report
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