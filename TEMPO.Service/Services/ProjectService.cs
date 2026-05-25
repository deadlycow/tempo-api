using TEMPO.Contracts.Dtos;
using TEMPO.Data.Interfaces;
using TEMPO.Domain.Common;
using TEMPO.Service.Command;
using TEMPO.Service.Factories;
using TEMPO.Service.Interfaces;

namespace TEMPO.Service.Services;

public class ProjectService(IProjectRepository projectRepository) : IProjectService
{
  private readonly IProjectRepository _projectRepository = projectRepository;

  public async Task<ServiceResult<ProjectResponse>> GetByIdAsync(Guid id, bool includeTimeEntries = false)
  {
    if (id == Guid.Empty)
      return ServiceResult<ProjectResponse>.Failure("Invalid project ID.");

    var project = await _projectRepository.GetByIdAsync(id, includeTimeEntries);
    if (project == null)
      return ServiceResult<ProjectResponse>.Failure("Project not found.");

    return ServiceResult<ProjectResponse>.SuccessResult(ProjectFactory.ToResponse(project));
  }
  public async Task<ServiceResult<IEnumerable<ProjectResponse>>> GetAllAsync()
  {
    var projects = await _projectRepository.GetAllAsync();
    return ServiceResult<IEnumerable<ProjectResponse>>.SuccessResult(ProjectFactory.ToResponseList(projects));
  }
  public async Task<ServiceResult<ProjectResponse>> CreateAsync(CreateProjectCommand command)
  {
    var entity = ProjectFactory.ToEntity(command);

    var created = await _projectRepository.CreateAsync(entity);
    
    return ServiceResult<ProjectResponse>.SuccessResult(ProjectFactory.ToResponse(created));
  }
  public async Task<ServiceResult> DeleteAsync(Guid id)
  {
    var project = await _projectRepository.GetByIdAsync(id);
    if (project == null)
      return ServiceResult.Failure("Project not found.");

    await _projectRepository.DeleteAsync(id);
    return ServiceResult.SuccessResult();
  }
  public async Task<ServiceResult<ProjectResponse>> UpdateAsync(UpdateProjectCommand command)
  {
    var existingProject = await _projectRepository.GetByIdAsync(command.Id);
    if (existingProject == null)
      return ServiceResult<ProjectResponse>.Failure("Project not found.");

    ProjectFactory.UpdateEntity(existingProject, command);
    if (!await _projectRepository.UpdateAsync(existingProject))
      return ServiceResult<ProjectResponse>.Failure("Failed to update project.");

    return ServiceResult<ProjectResponse>.SuccessResult(ProjectFactory.ToResponse(existingProject));
  }
}
