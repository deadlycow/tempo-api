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
    // public static List<ProjectModel> ToModelList(List<Project> projects)
    // {
    //     return projects.Select(ToModel).ToList();
    // }
    // public static IEnumerable<ProjectDto> CreateList(IEnumerable<ProjectEntity> entities) => entities.Select(Create).ToList();
}