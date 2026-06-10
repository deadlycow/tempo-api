using TEMPO.Data.Entities;

namespace TEMPO.Data.Interfaces;

public interface IReportRepository
{
  Task<Report?> GetByIdAndWeekAsync(string EmployeeId, DateOnly weekStart);
  Task<ICollection<Report>> GetAllByUserIdAsync(string EmployeeId);
  Task<Report> CreateAsync(Report report);
  Task DeleteAsync(Guid id);
  Task<bool> UpdateAsync(Report report);
}
