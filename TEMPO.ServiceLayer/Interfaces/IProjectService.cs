using TEMPO.Domain.Common;
using TEMPO.Domain.Models;
using TEMPO.ServiceLayer.Command;

namespace TEMPO.ServiceLayer.Interfaces;

public interface IProjectService
{
  Task<ServiceResult<IEnumerable<ProjectModel>>> GetAllAsync();
  Task<ServiceResult<ProjectModel>> GetByIdAsync(Guid id);
  Task<ServiceResult<ProjectModel>> CreateAsync(CreateProjectCommand command);
  Task<ServiceResult<string>> DeleteAsync(Guid id);
  Task<ServiceResult<string>> UpdateAsync(UpdateProjectCommand command);
}