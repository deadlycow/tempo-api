using Microsoft.EntityFrameworkCore;
using TEMPO.Data.Contexts;
using TEMPO.Data.Entities;
using TEMPO.Data.Interfaces;

namespace TEMPO.Data.Repositories;

public class TimeEntryRepository(ApplicationDbContext context) : ITimeEntryRepository
{
  private readonly ApplicationDbContext _context = context;
  private readonly DbSet<TimeEntry> _timeEntries = context.Set<TimeEntry>();
  public async Task<TimeEntry> GetByIdAsync(Guid id)
  {
    var timeEntry = await _timeEntries
      .FirstOrDefaultAsync(te => te.Id == id) ?? throw new InvalidOperationException("TimeEntry not found.");
    return timeEntry;
  }
  public async Task<IEnumerable<TimeEntry>> GetAllByUserIdAsync(Guid id)
  {
    return await _timeEntries
      .Where(te => te.EmployeeId == id.ToString())
      .ToListAsync();
  }
  public async Task<TimeEntry> CreateAsync(TimeEntry timeEntry)
  {
    await _timeEntries.AddAsync(timeEntry);
    await _context.SaveChangesAsync();

    return timeEntry;
  }
  public async Task DeleteAsync(Guid id)
  {
    var timeEntry = await _timeEntries.FindAsync(id);

    if (timeEntry == null)
      return;

    _timeEntries.Remove(timeEntry);
    await _context.SaveChangesAsync();
  }
  public async Task<bool> UpdateAsync(TimeEntry timeEntry)
  {
    _timeEntries.Update(timeEntry);
    return await _context.SaveChangesAsync() > 0;
  }
}