namespace TEMPO.Service.Command;

public record TimeEntryCommand
{
    public string? Description { get; init; }
}
public record CreateTimeEntryCommand : TimeEntryCommand
{
    public required Guid EmployeeId { get; init; }
    public required Guid ProjectId { get; init; }
    public required DateTime Date { get; init; }
    public required double HoursWorked { get; init; }
}
public record UpdateTimeEntryCommand : TimeEntryCommand
{
    public required Guid Id { get; init; }
    public Guid? EmployeeId { get; init; }
    public Guid? ProjectId { get; init; }
    public DateTime? Date { get; init; }
    public double? HoursWorked { get; init; }
}
public record GetTimeEntryCommand
{
    public required Guid Id { get; init; }
}