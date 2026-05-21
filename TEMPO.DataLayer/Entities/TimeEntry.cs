using Microsoft.AspNetCore.Identity;

namespace TEMPO.DataLayer.Entities;
public class TimeEntry
{
    public Guid Id { get; set; }
    public string EmployeeId { get; set; } = null!;
    public AppUser? Employee { get; set; }
    public DateTime Date { get; set; }
    public double HoursWorked { get; set; }
    public string? Description { get; set; }
    public Guid ProjectId { get; set; }
    public Project? Project { get; set; }
}