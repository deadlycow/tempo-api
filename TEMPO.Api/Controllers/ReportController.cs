using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TEMPO.Contracts.Dtos;
using TEMPO.Service.Command;
using TEMPO.Service.Services;

namespace TEMPO.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ReportController(ReportService report) : ControllerBase
{
    private readonly ReportService _report = report;

    [HttpPost]
    public async Task<ActionResult<ReportResponse>> Get([FromBody] GetReportRequest request)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrWhiteSpace(userId))
            return Unauthorized();

        var result = await _report.GetReportByIdAndDate(
            new GetReportCommand
            {
                UserId = userId,
                Date = request.Date
            }
        );

        if (!result.Success)
            return NotFound(result?.ErrorMessage ?? "No time entries found for the user.");

        return Ok(result.Data);
    }

    [HttpPost("upsert")]
    public async Task<ActionResult> Upsert([FromBody] ReportRequest request)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrWhiteSpace(userId))
            return Unauthorized();

        var result = await _report.Upsert(
            new ReportRequestCommand
            {
                Id = request.Id,
                UserId = userId,
                WeekStart = request.WeekStart,
                TimeEntries = request.TimeEntries
                .Select(x => new CreateTimeEntryCommand
                {
                    Id = Guid.TryParse(x.Id, out Guid id) ? id : null,
                    EmployeeId = userId,
                    ProjectId = x.ProjectId,
                    Date = x.Date,
                    HoursWorked = x.HoursWorked,
                    ReportId = x.ReportId ?? request.Id,
                    Description = x.Description
                }),
                Status = request.Status,
                SubmittedAt = request.SubmittedAt,
                VerifiedAt = request.VerifiedAt,
                RejectedAt = request.RejectedAt,
                SentAt = request.SentAt,
                Feedback = request.Feedback,
                ReviewedBy = request.ReviewedBy
            });
        if (!result.Success)
            return BadRequest(result?.ErrorMessage);

        return Created();
    }
}