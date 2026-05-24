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
        User = UserFactory.ToModel(entity.Employee!),
        HoursWorked = entity.HoursWorked,
        DateTime? startTime = null, // Placeholder for future implementation
        DateTime? endTime = null, // Placeholder for future implementation
        Description = entity.Description
    };
    /// <summary>
    /// Converts a list of TimeEntry entities to a list of TimeEntryModel objects.
    /// </summary>
    /// <param name="timeEntries"></param>
    /// <returns>IEnumerable<TimeEntryModel></returns>
    public static IEnumerable<TimeEntryModel> ToModelList(IEnumerable<TimeEntry> timeEntries) => [.. timeEntries.Select(ToModel)];
    public static TimeEntry ToEntity(CreateTimeEntryCommand command) => new()
    {
        EmployeeId = command.EmployeeId,
        Date = command.Date,
        HoursWorked = command.HoursWorked,
        Description = command.Description,
        ProjectId = command.ProjectId
    };

}