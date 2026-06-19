using TEMPO.Contracts.Dtos;
using TEMPO.Data.Entities;
using TEMPO.Service.Command;

namespace TEMPO.Service.Factories;

public static class ReportFactory
{
    public static Report ToEntity(ReportRequestCommand command)
    {
        var reportId = Guid.TryParse(command.Id, out Guid guid) ? guid : Guid.NewGuid();

        return new Report
        {
            Id = reportId,
            EmployeeId = command.UserId!,
            WeekStart = command.WeekStart,
            TimeEntry = [.. command.TimeEntries.Select(te => new TimeEntry
            {
                Id = te.Id ?? Guid.NewGuid(),
                EmployeeId = te.EmployeeId,
                Date = te.Date,
                HoursWorked = te.HoursWorked,
                Description = te.Description,
                ProjectId = te.ProjectId,
                ReportId = Guid.TryParse(te.ReportId, out Guid reportGuid) ? reportGuid : reportId
            })],
            Status = command.Status ?? "draft",
            SubmittedAt = command.SubmittedAt,
            VerifiedAt = command.VerifiedAt,
            RejectedAt = command.RejectedAt,
            SentAt = command.SentAt,
            FeedBack = command.Feedback,
            ReviewedBy = command.ReviewedBy,
        };
    }
    // public static IEnumerable<Report> ToReportList(IEnumerable<ReportRequestCommand> report) => [.. report.Select(ToEntity)];

    public static ReportResponse ToReportResponse(Report entity) => new()
    {
        Id = entity.Id,
        WeekStart = entity.WeekStart,
        Status = entity.Status,
        SubmittedAt = entity.SubmittedAt,
        VerifiedAt = entity.VerifiedAt,
        RejectedAt = entity.RejectedAt,
        SentAt = entity.SentAt,
        FeedBack = entity.FeedBack,
        ReviewedBy = entity.ReviewedBy,

        TimeEntries = entity.TimeEntry.Select(te => new TimeEntryResponse
        {
            Id = te.Id,
            ProjectId = te.ProjectId,
            EmployeeId = te.EmployeeId,
            HoursWorked = te.HoursWorked,
            Date = te.Date,
            Description = te.Description
        })
    };
    public static IEnumerable<ReportResponse> ToReportResponseList(IEnumerable<Report> report) => [.. report.Select(ToReportResponse)];
}