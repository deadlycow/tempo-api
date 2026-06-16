using TEMPO.Contracts.Dtos;
using TEMPO.Data.Entities;
using TEMPO.Data.Interfaces;
using TEMPO.Domain.Common;
using TEMPO.Domain.Helpers;
using TEMPO.Service.Command;
using TEMPO.Service.Factories;

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
  public async Task<ServiceResult> Upsert(ReportRequestCommand command)
  {
    if (string.IsNullOrEmpty(command.UserId))
      return ServiceResult.Failure("No user id");

    var date = WeekHelper.GetWeekStart(command.WeekStart);
    var report = await _report.GetByEmployeeAndWeek(command.UserId, date);

    if (report is null)
    {
      var data = await _report.CreateAsync(ReportFactory.ToEntity(command));
      // var data = _report.CreateAsync(new Report
      // {
      //   Id = Guid.TryParse(command.Id, out Guid guid) ? guid : Guid.NewGuid(),
      //   EmployeeId = command.UserId,
      //   WeekStart = command.WeekStart,
      //   TimeEntry = TimeEntryFactory.ToEntityList(command.TimeEntries),
      //   Status = command.Status ?? "draft",
      //   VerifiedAt = command.VerifiedAt,
      //   RejectedAt = command.RejectedAt,
      //   SentAt = command.SentAt,
      //   FeedBack = command.SentAt,
      //   ReviewedBy = command.ReviewedBy
      // });
      return ServiceResult.SuccessResult();
    }
    report.Status = command.Status ?? report.Status;
    report.SubmittedAt = command.SubmittedAt;
    report.VerifiedAt = command.VerifiedAt;
    report.RejectedAt = command.RejectedAt;
    report.SentAt = command.SentAt;
    report.FeedBack = command.Feedback;
    report.ReviewedBy = command.ReviewedBy;
    foreach (var entry in command.TimeEntries)
    {
      var existingEntry = report.TimeEntry.FirstOrDefault(x => x.Id == entry.Id);
      if (existingEntry is null)
        report.TimeEntry.Add(TimeEntryFactory.ToEntity(entry));
      else
      {
        existingEntry.Date = entry.Date;
        existingEntry.HoursWorked = entry.HoursWorked;
        existingEntry.ProjectId = entry.ProjectId;
        existingEntry.Description = entry.Description;
      }
    }

    await _report.UpdateAsync(report);



    return ServiceResult.Failure("Failed");

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