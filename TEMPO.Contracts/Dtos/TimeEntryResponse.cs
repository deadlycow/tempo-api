namespace TEMPO.Contracts.Dtos;
public record TimeEntryResponse
{
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public string EmployeeId { get; set; } = null!;
    public double? HoursWorked { get; set; }
    public DateTime? Date { get; set; }
    public string? Description { get; set; }
}