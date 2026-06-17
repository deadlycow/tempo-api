using System.Data.Common;

namespace TEMPO.Contracts.Dtos;

public record TimeEntryRequest
{
  public string? Description { get; init; }
};
public record CreateTimeEntryRequest : TimeEntryRequest
{
  public string? Id { get; init; }
  public required Guid ProjectId { get; init; }
  public required double HoursWorked { get; init; }
  public required DateOnly Date { get; init; }
  public string? ReportId { get; init; }
};
public record GetTimeEntryRequest
{
  public required Guid Id { get; init; }
};
public record UpdateTimeEntryRequest : TimeEntryRequest
{
  public required Guid Id { get; init; }
  public Guid? ProjectId { get; init; }
  public required string EmployeeId { get; init; }
  public double? HoursWorked { get; init; }
  public DateOnly? Date { get; init; }
  public required string ReportId { get; init; }
};
public record DeleteTimeEntryRequest
{
  public required Guid Id { get; init; }
};
public record GetAllTimeEntryByUserIdRequest
{
  public required Guid Id { get; init; }
}