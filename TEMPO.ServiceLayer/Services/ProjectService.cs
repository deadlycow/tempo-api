using TEMPO.DataLayer.Repositories;
using TEMPO.Domain.Models;
using TEMPO.ServiceLayer.Command;
using TEMPO.ServiceLayer.Factories;

namespace TEMPO.ServiceLayer.Services;

public class ProjectService(ProjectRepository projectRepository)
{
  private readonly ProjectRepository _projectRepository = projectRepository;
  public async Task<List<ProjectModel>> GetAllAsync()
  {
    var projects = await _projectRepository.GetAllAsync();
    return projects.Select(ProjectFactory.ToModel).ToList();
  }
  public async Task<string> GetProjectByIdAsync(Guid id)
  {
    // Logic to retrieve a specific project by ID from the database
    return $"Project with ID {id}";
  }
  public async Task<ProjectModel> CreateProjectAsync(CreateProjectCommand command)
  {
    var project = ProjectFactory.ToEntity(command);
    project = await _projectRepository.CreateProjectAsync(project);
    return ProjectFactory.ToModel(project);
  }
  public async Task<string> DeleteProjectAsync(Guid id)
  {
    // Logic to delete a project from the database
    return $"Project with ID {id} deleted successfully.";
  }
  public async Task<string> UpdateProjectAsync(Guid id, string projectName)
  {
    // Logic to update a project in the database
    return $"Project '{projectName}' updated successfully.";
  }
}