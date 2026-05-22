namespace TEMPO.Api.Dtos;

public record CreateTimeEntryRequest
(
  Guid ProjectId,
  string EmployeeId,
  double HoursWorked,
  DateTime Date,
  string? Description
);

public record GetTimeEntryRequest
(
  string Id
);