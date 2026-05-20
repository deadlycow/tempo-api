using Microsoft.EntityFrameworkCore;
using TEMPO.DataLayer.Contexts;
using TEMPO.DataLayer.Entities;
namespace TEMPO.DataLayer.Repositories;

public class TimeReportRepository(ApplicationDbContext context)
{
  private readonly ApplicationDbContext _context = context;
  public async Task<List<TimeReport>> GetAllByUserId(string userId)
  {
    if (string.IsNullOrWhiteSpace(userId))
      throw new ArgumentException("User ID cannot be null or empty.", nameof(userId));

    return await _context.TimeReports
      .Where(tr => tr.Id.ToString() == userId)
      .ToListAsync();
  }
}