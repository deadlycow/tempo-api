using TEMPO.DataLayer.Entities;
using TEMPO.DataLayer.Repositories;
using TEMPO.ServiceLayer.Factories;

namespace TEMPO.ServiceLayer.Services;

public class TimeEntryService(TimeEntryRepository timeEntryRepository)
{
 private readonly TimeEntryRepository _timeEntryRepository = timeEntryRepository;

 public Task<List<TimeEntryModel>> GetAllTimeEntriesAsync()
 {
    throw new NotImplementedException();

    //  return await _timeEntryRepository.GetAllAsync();
 }
 public Task<TimeEntryModel> GetTimeEntryByIdAsync(Guid id)
 {
  throw new NotImplementedException();
    //  return await _timeEntryRepository.GetByIdAsync(id);
 }
  public async Task<TimeEntryModel> CreateTimeEntryAsync(CreateTimeEntryCommand command)
  {
      var timeEntry = new TimeEntry
      {
          Id = Guid.NewGuid(),
          EmployeeId = command.EmployeeId,
          Date = command.Date,
          HoursWorked = command.HoursWorked,
          Description = command.Description,
          ProjectId = command.ProjectId
      };
  
      await _timeEntryRepository.CreateAsync(timeEntry);
      return TimeEntryFactory.ToModel(timeEntry);  
  }
}

public class TimeEntryModel
{
    public Guid Id { get; set; }
    public string EmployeeId { get; set; } = null!;
    public DateTime Date { get; set; }
    public double HoursWorked { get; set; }
    public string? Description { get; set; }
    public Guid ProjectId { get; set; }
}

public class CreateTimeEntryCommand
{
    public string EmployeeId { get; set; } = null!;
    public DateTime Date { get; set; }
    public double HoursWorked { get; set; }
    public string? Description { get; set; }
    public Guid ProjectId { get; set; }
}