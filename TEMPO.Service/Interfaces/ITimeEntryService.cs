using TEMPO.Service.Command;
using TEMPO.Domain.Common;
using TEMPO.Contracts.Dtos;

namespace TEMPO.Service.Interfaces;

public interface ITimeEntryService
{
  Task<ServiceResult<TimeEntryResponse>> CreateAsync(CreateTimeEntryCommand command);
  Task<ServiceResult> DeleteAsync(Guid id);
  Task<ServiceResult<IEnumerable<TimeEntryResponse>>> GetAllByUserIdAsync(GetTimeEntryCommand command);
  Task<ServiceResult<TimeEntryResponse>> GetByIdAsync(GetTimeEntryCommand command);
  Task<ServiceResult<TimeEntryResponse>> UpdateAsync(UpdateTimeEntryCommand command);
}

