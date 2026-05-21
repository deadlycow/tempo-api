using TEMPO.DataLayer.Entities;
using TEMPO.Domain.Models;
using TEMPO.ServiceLayer.Command;

namespace TEMPO.ServiceLayer.Factories;

public static class ProjectFactory
{
    public static Project ToEntity(CreateProjectCommand command)
    {
        return new Project
        {
            Id = Guid.NewGuid(),
            Name = command.Name,
            Description = command.Description,
            StartDate = command.StartDate,
            EndDate = command.EndDate
        };
    }
    public static ProjectModel ToModel(Project project)
    {
        return new ProjectModel
        {
            Id = project.Id,
            Name = project.Name,
            Description = project.Description,
            StartDate = project.StartDate,
            EndDate = project.EndDate
        };
    }
}