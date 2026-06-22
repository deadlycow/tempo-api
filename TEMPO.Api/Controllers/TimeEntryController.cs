using Microsoft.AspNetCore.Mvc;
using TEMPO.Service.Command;
using TEMPO.Contracts.Dtos;
using Microsoft.AspNetCore.Authorization;
using TEMPO.Service.Interfaces;
using System.Security.Claims;

namespace TEMPO.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class TimeEntryController(ITimeEntryService timeEntryService) : ControllerBase
{
    private readonly ITimeEntryService _timeEntryService = timeEntryService;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Get([FromQuery] GetTimeEntryRequest request)
    {
        var result = await _timeEntryService.GetByIdAsync(new GetTimeEntryCommand { Id = request.Id });
        if (!result.Success)
            return NotFound(result.ErrorMessage);
        return Ok(result.Data);
    }
    [HttpGet("allByUserId")]
    [ProducesResponseType(typeof(IEnumerable<TimeEntryResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetAll()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId))
            return Unauthorized();

        _ = Guid.TryParse(userId, out Guid result);
        var timeEntries = await _timeEntryService.GetAllByUserIdAsync(new GetTimeEntryCommand { Id = result });
        if (timeEntries == null || !timeEntries.Success)
            return NotFound(timeEntries?.ErrorMessage ?? "No time entries found.");
        return Ok(timeEntries);
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateTimeEntryRequest), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Post([FromBody] CreateTimeEntryRequest[] request)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrWhiteSpace(userId))
            return Unauthorized();

        var result = await _timeEntryService.CreateAsync([.. request.Select(item => new CreateTimeEntryCommand
        {
            ProjectId = item.ProjectId,
            EmployeeId = userId,
            HoursWorked = item.HoursWorked,
            Date = item.Date,
            Description = item.Description,
            ReportId = item.ReportId
        })]);

        if (!result.Success)
            return BadRequest(result.ErrorMessage);

        return CreatedAtAction(nameof(Get), new { id = result.Data?.FirstOrDefault()?.Id }, result.Data);
    }
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete([FromQuery] DeleteTimeEntryRequest id)
    {
        var result = await _timeEntryService.DeleteAsync(id.Id);

        if (!result.Success)
            return NotFound(result.ErrorMessage);

        return NoContent();
    }
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Update([FromBody] UpdateTimeEntryRequest request)
    {
        var result = await _timeEntryService.UpdateAsync(new UpdateTimeEntryCommand
        {
            Id = request.Id,
            ProjectId = request.ProjectId,
            EmployeeId = request.EmployeeId,
            Date = request.Date,
            HoursWorked = request.HoursWorked,
            Description = request.Description,
        });
        if (!result.Success)
            return BadRequest(result.ErrorMessage);
        return Ok(result.Data);
    }
}
