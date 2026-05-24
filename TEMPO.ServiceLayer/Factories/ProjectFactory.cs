using TEMPO.DataLayer.Entities;
using TEMPO.Domain.Models;
using TEMPO.ServiceLayer.Command;

namespace TEMPO.ServiceLayer.Factories;

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
    public static ProjectModel ToModel(Project project) => new()
    {
        Id = project.Id,
        Name = project.Name,
        Description = project.Description,
        StartDate = project.StartDate,
        EndDate = project.EndDate
    };
    public static IEnumerable<ProjectModel> ToModelList(IEnumerable<Project> projects) => [.. projects.Select(ToModel)];
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