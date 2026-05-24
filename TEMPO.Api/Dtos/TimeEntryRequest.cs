namespace TEMPO.Api.Dtos;

public record CreateTimeEntryRequest
(
  Guid ProjectId,
  Guid EmployeeId,
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
  Guid Id,
  Guid ProjectId,
  Guid EmployeeId,
  double HoursWorked,
  DateTime Date,
  string? Description
);
public record DeleteTimeEntryRequest
(
  Guid Id
);