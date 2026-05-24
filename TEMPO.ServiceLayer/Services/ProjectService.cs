using TEMPO.DataLayer.Interfaces;
using TEMPO.Domain.Common;
using TEMPO.Domain.Models;
using TEMPO.ServiceLayer.Command;
using TEMPO.ServiceLayer.Factories;
using TEMPO.ServiceLayer.Interfaces;

namespace TEMPO.ServiceLayer.Services;

public class ProjectService(IProjectRepository projectRepository) : IProjectService
{
  private readonly IProjectRepository _projectRepository = projectRepository;

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
      return ServiceResult<ProjectModel>.Failure("Project not found.");

    return ServiceResult<ProjectModel>.SuccessResult(ProjectFactory.ToModel(project));
  }
  public async Task<ServiceResult<ProjectModel>> CreateAsync(CreateProjectCommand command)
  {
    var entity = ProjectFactory.ToEntity(command);

    var created = await _projectRepository.CreateAsync(entity);
    
    return ServiceResult<ProjectModel>.SuccessResult(ProjectFactory.ToModel(created));
  }
  public async Task<ServiceResult> DeleteAsync(Guid id)
  {
    var project = await _projectRepository.GetByIdAsync(id);
    if (project == null)
      return ServiceResult.Failure("Project not found.");

    await _projectRepository.DeleteAsync(id);
    return ServiceResult.SuccessResult();
  }
  public async Task<ServiceResult<ProjectModel>> UpdateAsync(UpdateProjectCommand command)
  {
    var existingProject = await _projectRepository.GetByIdAsync(command.Id);
    if (existingProject == null)
      return ServiceResult<ProjectModel>.Failure("Project not found.");

    ProjectFactory.UpdateEntity(existingProject, command);
    if (!await _projectRepository.UpdateAsync(existingProject))
      return ServiceResult<ProjectModel>.Failure("Failed to update project.");

    return ServiceResult<ProjectModel>.SuccessResult(ProjectFactory.ToModel(existingProject));
  }
}
