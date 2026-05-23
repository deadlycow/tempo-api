using TEMPO.DataLayer.Repositories;
using TEMPO.Domain.Common;
using TEMPO.Domain.Models;
using TEMPO.ServiceLayer.Command;
using TEMPO.ServiceLayer.Factories;
using TEMPO.ServiceLayer.Interfaces;

namespace TEMPO.ServiceLayer.Services;

public class ProjectService(ProjectRepository projectRepository) : IProjectService
{
  private readonly ProjectRepository _projectRepository = projectRepository;
  public async Task<ServiceResult<IEnumerable<ProjectModel>>> GetAllAsync()
  {
    var projects = await _projectRepository.GetAllAsync();
    return ServiceResult<IEnumerable<ProjectModel>>.SuccessResult(ProjectFactory.ToModelList(projects));
  }
  public async Task<ServiceResult<ProjectModel>> GetByIdAsync(Guid id)
  {
    if (id == Guid.Empty)
      return ServiceResult<ProjectModel>.Failure("Invalid project ID.");

    var project = await _projectRepository.GetByIdAsync(id);
    if (project == null)
      return ServiceResult<ProjectModel>.Failure($"Project with ID {id} not found.");

    return ServiceResult<ProjectModel>.SuccessResult(ProjectFactory.ToModel(project));
  }
  public async Task<ServiceResult<ProjectModel>> CreateAsync(CreateProjectCommand command)
  {
    var project = ProjectFactory.ToEntity(command);
    project = await _projectRepository.CreateAsync(project);
    return ServiceResult<ProjectModel>.SuccessResult(ProjectFactory.ToModel(project));
  }
  public async Task<ServiceResult> DeleteAsync(Guid id)
  {
    var project = await _projectRepository.GetByIdAsync(id);
    if (project == null)
      return ServiceResult.Failure($"Project with ID {id} not found.");

    await _projectRepository.DeleteAsync(id);
    return ServiceResult.SuccessResult();
  }
  public async Task<ServiceResult<string>> UpdateAsync(UpdateProjectCommand command)
  {
    return ServiceResult<string>.SuccessResult($"Project '{command.Name}' updated successfully.");
  }
}
