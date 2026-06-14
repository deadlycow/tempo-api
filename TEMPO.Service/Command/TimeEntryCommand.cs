namespace TEMPO.Service.Command;

public record TimeEntryCommand
{
    public string? Description { get; init; }
}
public record CreateTimeEntryCommand : TimeEntryCommand
{
    public Guid? Id { get; init; }
    public required string EmployeeId { get; init; }
    public required Guid ProjectId { get; init; }
    public required DateOnly Date { get; init; }
    public required double HoursWorked { get; init; }
    public string? ReportId { get; init; }
}
public record UpdateTimeEntryCommand : TimeEntryCommand
{
    public required Guid Id { get; init; }
    public required string EmployeeId { get; init; }
    public Guid? ProjectId { get; init; }
    public DateOnly? Date { get; init; }
    public double? HoursWorked { get; init; }
}
public record GetTimeEntryCommand
{
    public required Guid Id { get; init; }
}