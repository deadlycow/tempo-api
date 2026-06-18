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
            TimeEntry = [.. command.TimeEntries.Select(x => new TimeEntry
            {
                Id = x.Id ?? Guid.NewGuid(),
                EmployeeId = x.EmployeeId,
                Date = x.Date,
                HoursWorked = x.HoursWorked,
                Description = x.Description,
                ProjectId = x.ProjectId,
                ReportId = Guid.TryParse(x.ReportId, out Guid reportGuid) ? reportGuid : reportId
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

    public static ReportResponse ToReportResponse(Report entity)
    {
        return new ReportResponse
        {
            Id = entity.Id,
            Status = entity.Status,
            SubmittedAt = entity.SubmittedAt,
            VerifiedAt = entity.VerifiedAt,
            RejectedAt = entity.RejectedAt,
            SentAt = entity.SentAt,
            FeedBack = entity.FeedBack,
            ReviewedBy = entity.ReviewedBy
        };
    }
    public static IEnumerable<ReportResponse> ToReportResponseList(IEnumerable<Report> report) => [.. report.Select(ToReportResponse)];
}