using TEMPO.Data.Entities;

namespace TEMPO.Data.Interfaces;

public interface IReportRepository
{
  Task<Report> CreateAsync(Report report);
  Task DeleteAsync(Guid id);
  Task<ICollection<Report>> GetAllByUserIdAsync(Guid id);
  Task<Report> GetByIdAsync(Guid id);
  Task<bool> UpdateAsync(Report report);
}
