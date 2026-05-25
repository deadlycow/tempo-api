using TEMPO.Domain.Common;
using TEMPO.Domain.Models;
using TEMPO.ServiceLayer.Command;

namespace TEMPO.ServiceLayer.Interfaces;

public interface IProjectService
{
  Task<ServiceResult<ProjectModel>> GetByIdAsync(Guid id, bool includeTimeEntries = false);
  Task<ServiceResult<IEnumerable<ProjectModel>>> GetAllAsync();
  Task<ServiceResult<ProjectModel>> CreateAsync(CreateProjectCommand command);
  Task<ServiceResult> DeleteAsync(Guid id);
  Task<ServiceResult<ProjectModel>> UpdateAsync(UpdateProjectCommand command);
}