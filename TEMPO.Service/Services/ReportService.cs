using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Microsoft.Identity.Client;
using TEMPO.Contracts.Dtos;
using TEMPO.Data.Interfaces;
using TEMPO.Domain.Common;
using TEMPO.Domain.Helpers;
using TEMPO.Service.Command;

namespace TEMPO.Service.Services;

public class ReportService(IReportRepository report)
{
  private readonly IReportRepository _report = report;

  public async Task<ServiceResult<ReportResponse>> GetReportByIdAndDate(GetReportCommand command)
  {
    var date = WeekHelper.GetWeekStart(command.Date);
    var result = await _report.GetByEmployeeAndWeek(command.UserId, date);

    if (result == null)
      return ServiceResult<ReportResponse>.Failure("Report not found");

    var data = new ReportResponse
    {
      Id = result.Id,
      Status = result.Status,
      SubmittedAt = result.SubmittedAt,
      VerifiedAt = result.VerifiedAt,
      RejectedAt = result.RejectedAt,
      SentAt = result.SentAt,
      FeedBack = result.FeedBack,
      ReviewedBy = result.ReviewedBy,

      TimeEntries = [.. result.TimeEntry.Select(te => new TimeEntryResponse
      {
        Id = te.Id,
        ProjectId = te.ProjectId,
        EmployeeId = te.EmployeeId,
        HoursWorked = te.HoursWorked,
        Date = te.Date,
        Description = te.Description
      })]
    };

    return ServiceResult<ReportResponse>.SuccessResult(data);
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