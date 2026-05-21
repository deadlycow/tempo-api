using TEMPO.DataLayer.Entities;
using TEMPO.ServiceLayer.Services;

namespace TEMPO.ServiceLayer.Factories;

public static class TimeEntryFactory
{
    public static TimeEntryModel ToModel(TimeEntry timeEntry)
    {
        if (timeEntry == null)
            throw new ArgumentNullException(nameof(timeEntry), "Time entry cannot be null.");

        return new TimeEntryModel
        {
            Id = timeEntry.Id,
            EmployeeId = timeEntry.EmployeeId,
            Date = timeEntry.Date,
            HoursWorked = timeEntry.HoursWorked,
            Description = timeEntry.Description,
            ProjectId = timeEntry.ProjectId
        };
    }
}