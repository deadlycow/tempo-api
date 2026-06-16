using TEMPO.Data.Entities;
using TEMPO.Service.Command;

namespace TEMPO.Service.Factories;

public static class ReportFactory
{
    public static Report ToEntity(ReportRequestCommand command) => new()
    {
        Id = Guid.TryParse(command.Id, out Guid guid) ? guid : Guid.NewGuid(),
        EmployeeId = command.UserId!,
        WeekStart = command.WeekStart,
        TimeEntry = [.. command.TimeEntries.Select(x => new TimeEntry
        {
            Id = x.Id ?? Guid.NewGuid(),
            EmployeeId = x.EmployeeId,
            Date = x.Date,
            HoursWorked =x.HoursWorked,
            Description = x.Description,
            ProjectId = x.ProjectId,
            ReportId = Guid.TryParse(x.ReportId, out Guid guid) ? guid : Guid.NewGuid()
        })],
        Status = command.Status ?? "draft",
        SubmittedAt = command.SubmittedAt,
        VerifiedAt = command.VerifiedAt,
        RejectedAt = command.RejectedAt,
        SentAt = command.SentAt,
        FeedBack = command.Feedback,
        ReviewedBy = command.ReviewedBy,
    };
    // public static IEnumerable<Report> ToReportList(IEnumerable<ReportRequestCommand> report) => [.. report.Select(ToEntity)];
}