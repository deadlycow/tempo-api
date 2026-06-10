using System.Diagnostics.CodeAnalysis;
using Microsoft.Identity.Client;
using TEMPO.Data.Interfaces;
using TEMPO.Domain.Common;

namespace TEMPO.Service.Services;

public class ReportService(IReportRepository report)
{
  private readonly IReportRepository _report = report;

  public async Task<ServiceResult> CreateAsync()
  {
    
    return ServiceResult.SuccessResult();
  }
}





// public interface IReportRepository
// {
//   Task<Report> CreateAsync(Report report);
//   Task DeleteAsync(Guid id);
//   Task<ICollection<Report>> GetAllByUserIdAsync(Guid id);
//   Task<Report> GetByIdAsync(Guid id);
//   Task<bool> UpdateAsync(Report report);
// }