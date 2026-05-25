using TEMPO.Contracts.Dtos;
using TEMPO.Data.Entities;
using TEMPO.Service.Command;

namespace TEMPO.Service.Factories;

public static class ProjectFactory
{
    public static Project ToEntity(CreateProjectCommand command) => new()
    {
        Id = Guid.NewGuid(),
        Name = command.Name,
        Description = command.Description,
        StartDate = command.StartDate,
        EndDate = command.EndDate
    };
    public static ProjectResponse ToResponse(Project project) => new()
    {
        Id = project.Id,
        Name = project.Name,
        Description = project.Description,
        StartDate = project.StartDate,
        EndDate = project.EndDate,
        TimeEntries = [.. project.TimeEntries.Select(TimeEntryFactory.ToResponse)]
    };
    public static IEnumerable<ProjectResponse> ToResponseList(IEnumerable<Project> projects) => [.. projects.Select(ToResponse)];
    public static void UpdateEntity(Project project, UpdateProjectCommand command)
    {
        if (command.Name is not null)
            project.Name = command.Name;
        if (command.Description is not null)
            project.Description = command.Description;
        if (command.Description is not null)
            project.Description = command.Description;
        if (command.StartDate.HasValue)
            project.StartDate = command.StartDate.Value;
        if (command.EndDate.HasValue)
            project.EndDate = command.EndDate.Value;
    }
}