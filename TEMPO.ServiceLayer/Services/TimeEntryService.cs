using TEMPO.DataLayer.Interfaces;
using TEMPO.ServiceLayer.Factories;
using TEMPO.ServiceLayer.Command;
using TEMPO.Domain.Models;
using TEMPO.Domain.Common;

namespace TEMPO.ServiceLayer.Services;

public class TimeEntryService(ITimeEntryRepository timeEntryRepository)
{
    private readonly ITimeEntryRepository _timeEntryRepository = timeEntryRepository;

    public async Task<ServiceResult<TimeEntryModel>> GetByIdAsync(GetTimeEntryCommand command)
    {
        var entity = await _timeEntryRepository.GetByIdAsync(command.Id);
        if (entity == null)
            return ServiceResult<TimeEntryModel>.Failure("");

        return ServiceResult<TimeEntryModel>.SuccessResult(TimeEntryFactory.ToModel(entity));
    }
    public async Task<ServiceResult<IEnumerable<TimeEntryModel>>> GetAllByUserIdAsync(GetTimeEntryCommand command)
    {
        var timeEntries = await _timeEntryRepository.GetAllByUserIdAsync(command.Id);
        if (timeEntries == null)
            return ServiceResult<IEnumerable<TimeEntryModel>>.Failure("TimeEntrys not found");

        return ServiceResult<IEnumerable<TimeEntryModel>>.SuccessResult(TimeEntryFactory.ToModelList(timeEntries));
    }
    public async Task<ServiceResult<TimeEntryModel>> CreateAsync(CreateTimeEntryCommand command)
    {
        var entity = TimeEntryFactory.ToEntity(command);

        var created = await _timeEntryRepository.CreateAsync(entity);

        return ServiceResult<TimeEntryModel>.SuccessResult(TimeEntryFactory.ToModel(created));
    }
    public async Task<ServiceResult> DeleteAsync(Guid id)
    {
        var timeEntry = await _timeEntryRepository.GetByIdAsync(id);
        if (timeEntry == null)
            return ServiceResult.Failure("TimeEntry not found.");

        await _timeEntryRepository.DeleteAsync(id);
        return ServiceResult.SuccessResult();
    }
    public async Task<ServiceResult<TimeEntryModel>> UpdateAsync(UpdateTimeEntryCommand command)
    {
        var entity = await _timeEntryRepository.GetByIdAsync(command.Id);
        if (entity == null)
            return ServiceResult<TimeEntryModel>.Failure("TimeEntry not found.");

        TimeEntryFactory.UpdateEntity(entity, command);
        if (!await _timeEntryRepository.UpdateAsync(entity))
            return ServiceResult<TimeEntryModel>.Failure("Failed to update timeEntry.");

        return ServiceResult<TimeEntryModel>.SuccessResult(TimeEntryFactory.ToModel(entity));
    }
}