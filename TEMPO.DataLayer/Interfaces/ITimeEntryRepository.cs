using TEMPO.DataLayer.Entities;
namespace TEMPO.DataLayer.Interfaces;

public interface ITimeEntryRepository
{
  Task<IEnumerable<TimeEntry>> GetAllByUserIdAsync(Guid id);
  Task<TimeEntry> GetByIdAsync(Guid id);
  Task<TimeEntry> CreateAsync(TimeEntry timeEntry);
  Task DeleteAsync(Guid id);
  Task<bool> UpdateAsync(TimeEntry timeEntry);
}
