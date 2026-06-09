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
    public Guid ReportId { get; set; }
    public Report Report { get; set; } = null!;
}