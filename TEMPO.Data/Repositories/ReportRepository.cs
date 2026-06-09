using Microsoft.EntityFrameworkCore;
using TEMPO.Data.Contexts;
using TEMPO.Data.Entities;
using TEMPO.Data.Interfaces;

namespace TEMPO.Data.Repositories;

public class ReportRepository(ApplicationDbContext context) : IReportRepository
{
  private readonly ApplicationDbContext _context = context;
  private readonly DbSet<Report> _report = context.Set<Report>();

  public async Task<Report> GetByIdAsync(Guid id)
  {
    var report = await _report
    .FirstOrDefaultAsync(r => r.Id == id) ?? throw new InvalidOperationException("Report not found");
    return report;
  }
  public async Task<ICollection<Report>> GetAllByUserIdAsync(Guid id)
  {
    var reports = await _report
    .Where(r => r.EmployeeId == id.ToString()).ToListAsync();
    return reports;
  }
  public async Task<Report> CreateAsync(Report report)
  {
    await _report.AddAsync(report);
    await _context.SaveChangesAsync();

    return report;
  }
  public async Task DeleteAsync(Guid id)
  {
    var report = await _report.FindAsync(id);

    if (report == null)
      return;

    _report.Remove(report);
    await _context.SaveChangesAsync();
  }
  public async Task<bool> UpdateAsync(Report report)
  {
    _report.Update(report);
    return await _context.SaveChangesAsync() > 0;
  }
}
