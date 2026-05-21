namespace TEMPO.Api.Dtos.TimeReport;

public record CreateTimeEntryRequest
(
  Guid ProjectId,
  string EmployeeId,
  double HoursWorked,
  DateTime Date,
  string? Description
);