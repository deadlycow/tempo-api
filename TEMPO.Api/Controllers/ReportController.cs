using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TEMPO.Contracts.Dtos;
using TEMPO.Data.Entities;
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
    public async Task<ActionResult<ReportResponse>> Get([FromBody] ReportRequest request)
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
}