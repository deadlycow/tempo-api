namespace TEMPO.ServiceLayer.Command;

public record TimeEntryCommand
{
    public required Guid EmployeeId { get; init; }
    public required Guid ProjectId { get; init; }
    public DateTime Date { get; init; }
    public double HoursWorked { get; init; }
    public string? Description { get; init; }
}

public record CreateTimeEntryCommand : TimeEntryCommand
{
}

public record UpdateTimeEntryCommand : TimeEntryCommand
{
    public required Guid Id { get; init; }
}