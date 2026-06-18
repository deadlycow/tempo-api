using TEMPO.Contracts.Dtos;
using TEMPO.Data.Entities;
using TEMPO.Data.Interfaces;
using TEMPO.Domain.Common;
using TEMPO.Domain.Helpers;
using TEMPO.Service.Command;
using TEMPO.Service.Factories;

namespace TEMPO.Service.Services;

public class ReportService(IReportRepository report, ITimeEntryRepository timeEntry)
{
  private readonly IReportRepository _report = report;
  private readonly ITimeEntryRepository _timeEntry = timeEntry;

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
      return ServiceResult.SuccessResult();
    }

    var incomingIds = command.TimeEntries.Where(x => x.Id.HasValue).Select(x => x.Id!.Value).ToHashSet();
    var toRemove = report.TimeEntry.Where(x => !incomingIds.Contains(x.Id)).ToList();
    foreach (var entry in toRemove)
    {
      await _timeEntry.DeleteAsync(entry.Id);
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
      {
        var newEntry = TimeEntryFactory.ToEntity(entry);
        report.TimeEntry.Add(newEntry);
      }
      else
      {
        existingEntry.Date = entry.Date;
        existingEntry.HoursWorked = entry.HoursWorked;
        existingEntry.ProjectId = entry.ProjectId;
        existingEntry.Description = entry.Description;
        existingEntry.ReportId = report.Id;
      }
    }

    return await _report.UpdateAsync(report) ? ServiceResult.SuccessResult() : ServiceResult.Failure("Failed");
  }
  public async Task<ServiceResult<IEnumerable<ReportResponse>>> GetAllByUserId(string id)
  {
    var reports = await _report.GetAllByUserIdAsync(id);

      var data = ReportFactory.ToReportResponseList(reports);
       
    return ServiceResult<IEnumerable<ReportResponse>>.SuccessResult(data);
  }
}