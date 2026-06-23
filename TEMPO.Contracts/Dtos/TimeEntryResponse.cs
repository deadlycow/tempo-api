namespace TEMPO.Contracts.Dtos;
public record TimeEntryResponse
{
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public required string EmployeeId { get; set; }
    public double? HoursWorked { get; set; }
    public DateOnly? Date { get; set; }
    public string? Description { get; set; }
}