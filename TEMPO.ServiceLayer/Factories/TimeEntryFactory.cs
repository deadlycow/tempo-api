using TEMPO.DataLayer.Entities;
using TEMPO.Domain.Models;
using TEMPO.ServiceLayer.Command;

namespace TEMPO.ServiceLayer.Factories;

public static class TimeEntryFactory
{
    public static TimeEntryModel ToModel(TimeEntry entity) => new()
    {
        Id = entity.Id,
        ProjectId = entity.ProjectId,
        EmployeeId = entity.EmployeeId,
        HoursWorked = entity.HoursWorked,
        Date = entity.Date,
        Description = entity.Description
    };
    public static IEnumerable<TimeEntryModel> ToModelList(IEnumerable<TimeEntry> timeEntries) => [.. timeEntries.Select(ToModel)];
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
        entity.ProjectId = command.ProjectId;
        entity.HoursWorked = command.HoursWorked;
        entity.Date = command.Date;
        entity.Description = command.Description;
    }
}