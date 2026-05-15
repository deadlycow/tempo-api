using Microsoft.AspNetCore.Identity;

namespace TEMPO.DataLayer.Entities;
public class TimeReport
{
    public Guid Id { get; set; }
    public string EmployeeId { get; set; } = null!;
    public TempoUser? Employee { get; set; }
    public DateTime Date { get; set; }
    public double HoursWorked { get; set; }
    public string? Description { get; set; }
    public Guid ProjectId { get; set; }
    public Project? Project { get; set; }
    public ICollection<TimeReport> TimeReports { get; set; } = new List<TimeReport>();
}