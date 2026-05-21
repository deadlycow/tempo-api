using Microsoft.EntityFrameworkCore;
using TEMPO.DataLayer.Contexts;
using TEMPO.DataLayer.Entities;
namespace TEMPO.DataLayer.Repositories;

public class TimeEntryRepository(ApplicationDbContext context)
{
  private readonly ApplicationDbContext _context = context;
  public async Task<List<TimeEntry>> GetAllByUserId(string userId)
  {
    if (string.IsNullOrWhiteSpace(userId))
      throw new ArgumentException("User ID cannot be null or empty.", nameof(userId));

    return await _context.TimeEntries
      .Where(te => te.EmployeeId == userId)
      .ToListAsync();
  }
  public async Task<TimeEntry?> GetById(Guid id)
  {
    if (id == Guid.Empty)
      throw new ArgumentException("ID cannot be empty.", nameof(id));

    return await _context.TimeEntries
      .FirstOrDefaultAsync(te => te.Id == id);
  }
  public async Task CreateAsync(TimeEntry timeEntry)
  {
    if (timeEntry == null)
      throw new ArgumentNullException(nameof(timeEntry), "Time entry cannot be null.");

    await _context.TimeEntries.AddAsync(timeEntry);
    await _context.SaveChangesAsync();
  }
}