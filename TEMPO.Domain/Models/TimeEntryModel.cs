namespace TEMPO.Domain.Models;

public class TimeEntryModel
{
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public string EmployeeId { get; set; } = null!;
    public double? HoursWorked { get; set; }
    public DateTime? Date { get; set; }
    public string? Description { get; set; }
}