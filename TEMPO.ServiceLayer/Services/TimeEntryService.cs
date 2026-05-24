using TEMPO.DataLayer.Repositories;
using TEMPO.ServiceLayer.Factories;
using TEMPO.ServiceLayer.Command;
using TEMPO.Domain.Models;

namespace TEMPO.ServiceLayer.Services;

public class TimeEntryService(TimeEntryRepository timeEntryRepository)
{
    private readonly TimeEntryRepository _timeEntryRepository = timeEntryRepository;

    public Task<TimeEntryModel> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
    public Task<IEnumerable<TimeEntryModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
    public async Task<TimeEntryModel> CreateTimeEntryAsync(CreateTimeEntryCommand command)
    {
        var timeEntry = TimeEntryFactory.ToEntity(command);


        await _timeEntryRepository.CreateAsync(timeEntry);
        return TimeEntryFactory.ToModel(timeEntry);
    }
    public Task DeleteTimeEntryAsync(Guid id)
    {
        throw new NotImplementedException();
    }
    public Task<TimeEntryModel> UpdateTimeEntryAsync(UpdateTimeEntryCommand command)
    {
        throw new NotImplementedException();
    }
}