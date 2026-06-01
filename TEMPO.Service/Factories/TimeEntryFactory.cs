using TEMPO.Contracts.Dtos;
using TEMPO.Data.Entities;
using TEMPO.Service.Command;

namespace TEMPO.Service.Factories;

public static class TimeEntryFactory
{
    public static TimeEntryResponse ToResponse(TimeEntry entity) => new()
    {
        Id = entity.Id,
        ProjectId = entity.ProjectId,
        EmployeeId = entity.EmployeeId,
        HoursWorked = entity.HoursWorked,
        Date = entity.Date,
        Description = entity.Description
    };
    public static IEnumerable<TimeEntryResponse> ToResponseList(IEnumerable<TimeEntry> timeEntries) => [.. timeEntries.Select(ToResponse)];
    public static TimeEntry ToEntity(CreateTimeEntryCommand command) => new()
    {
        ProjectId = command.ProjectId,
        EmployeeId = command.EmployeeId.ToString(),
        HoursWorked = command.HoursWorked,
        Date = command.Date,
        Description = command.Description
    };
    public static IEnumerable<TimeEntry> ToEntityList(IEnumerable<CreateTimeEntryCommand> commands) => [.. commands.Select(ToEntity)];
    public static void UpdateEntity(TimeEntry entity, UpdateTimeEntryCommand command)
    {
        if (command.ProjectId.HasValue)
            entity.ProjectId = command.ProjectId.Value;
        if (command.HoursWorked.HasValue)
            entity.HoursWorked = command.HoursWorked.Value;
        if (command.Date.HasValue)
            entity.Date = command.Date.Value;
        if (command.Description is not null)
            entity.Description = command.Description;
    }
}