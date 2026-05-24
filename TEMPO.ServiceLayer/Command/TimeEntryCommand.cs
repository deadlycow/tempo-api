namespace TEMPO.ServiceLayer.Command;

public class CreateTimeEntryCommand
{
    public required Guid EmployeeId { get; set; }
    public DateTime Date { get; set; }
    public double? HoursWorked { get; set; }
    public string? Description { get; set; }
    public required Guid ProjectId { get; set; }
}