namespace TEMPO.Domain.Models;

public class TimeEntryModel
{
    // public Guid Id { get; set; }
    // public Guid ProjectId { get; set; }
    // public Guid UserId { get; set; }
    public required UserModel User { get; set; }
    public double? HoursWorked { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public string? Description { get; set; }
}