using TEMPO.Contracts.Dtos;
using TEMPO.Domain.Common;
using TEMPO.Service.Command;

namespace TEMPO.Service.Interfaces;

public interface IProjectService
{
  Task<ServiceResult<ProjectResponse>> GetByIdAsync(Guid id, bool includeTimeEntries = false);
  Task<ServiceResult<IEnumerable<ProjectResponse>>> GetAllAsync();
  Task<ServiceResult<ProjectResponse>> CreateAsync(CreateProjectCommand command);
  Task<ServiceResult> DeleteAsync(Guid id);
  Task<ServiceResult<ProjectResponse>> UpdateAsync(UpdateProjectCommand command);
}