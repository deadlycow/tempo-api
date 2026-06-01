using TEMPO.Data.Interfaces;
using TEMPO.Service.Factories;
using TEMPO.Service.Command;
using TEMPO.Service.Interfaces;
using TEMPO.Domain.Common;
using TEMPO.Contracts.Dtos;

namespace TEMPO.Service.Services;

public class TimeEntryService(ITimeEntryRepository timeEntryRepository) : ITimeEntryService
{
  private readonly ITimeEntryRepository _timeEntryRepository = timeEntryRepository;

  public async Task<ServiceResult<TimeEntryResponse>> GetByIdAsync(GetTimeEntryCommand command)
  {
    var entity = await _timeEntryRepository.GetByIdAsync(command.Id);
    if (entity == null)
      return ServiceResult<TimeEntryResponse>.Failure("");

    return ServiceResult<TimeEntryResponse>.SuccessResult(TimeEntryFactory.ToResponse(entity));
  }
  public async Task<ServiceResult<IEnumerable<TimeEntryResponse>>> GetAllByUserIdAsync(GetTimeEntryCommand command)
  {
    var timeEntries = await _timeEntryRepository.GetAllByUserIdAsync(command.Id);
    if (timeEntries == null)
      return ServiceResult<IEnumerable<TimeEntryResponse>>.Failure("TimeEntrys not found");

    return ServiceResult<IEnumerable<TimeEntryResponse>>.SuccessResult(TimeEntryFactory.ToResponseList(timeEntries));
  }
  public async Task<ServiceResult<TimeEntryResponse>> CreateAsync(CreateTimeEntryCommand command)
  {
    var entity = TimeEntryFactory.ToEntity(command);

    var created = await _timeEntryRepository.CreateAsync(entity);

    return ServiceResult<TimeEntryResponse>.SuccessResult(TimeEntryFactory.ToResponse(created));
  }
  public async Task<ServiceResult> DeleteAsync(Guid id)
  {
    var timeEntry = await _timeEntryRepository.GetByIdAsync(id);
    if (timeEntry == null)
      return ServiceResult.Failure("TimeEntry not found.");

    await _timeEntryRepository.DeleteAsync(id);
    return ServiceResult.SuccessResult();
  }
  public async Task<ServiceResult<TimeEntryResponse>> UpdateAsync(UpdateTimeEntryCommand command)
  {
    var entity = await _timeEntryRepository.GetByIdAsync(command.Id);
    if (entity == null)
      return ServiceResult<TimeEntryResponse>.Failure("TimeEntry not found.");

    TimeEntryFactory.UpdateEntity(entity, command);
    if (!await _timeEntryRepository.UpdateAsync(entity))
      return ServiceResult<TimeEntryResponse>.Failure("Failed to update timeEntry.");

    return ServiceResult<TimeEntryResponse>.SuccessResult(TimeEntryFactory.ToResponse(entity));
  }
}

