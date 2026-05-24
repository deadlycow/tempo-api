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
  Guid Id
);
public record UpdateTimeEntryRequest
(
  Guid ProjectId,
  string EmployeeId,
  double HoursWorked,
  DateTime Date,
  string? Description
);
public record DeleteTimeEntryRequest
(
  Guid Id
);