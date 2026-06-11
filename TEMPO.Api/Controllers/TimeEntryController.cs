using Microsoft.AspNetCore.Mvc;
using TEMPO.Service.Command;
using TEMPO.Contracts.Dtos;
using Microsoft.AspNetCore.Authorization;
using TEMPO.Service.Interfaces;

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
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetAll([FromQuery] GetAllTimeEntryByUserIdRequest request)
    {
        var timeEntries = await _timeEntryService.GetAllByUserIdAsync(new GetTimeEntryCommand { Id = request.Id });
        if (timeEntries == null || !timeEntries.Success)
            return NotFound(timeEntries?.ErrorMessage ?? "No time entries found for the user.");
        return Ok(timeEntries);
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateTimeEntryRequest), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Post(CreateTimeEntryRequest request)
    {
        var result = await _timeEntryService.CreateAsync(new CreateTimeEntryCommand
        {
            ProjectId = request.ProjectId,
            EmployeeId = request.EmployeeId,
            HoursWorked = request.HoursWorked,
            Date = request.Date,
            Description = request.Description
        });
        if (!result.Success)
            return BadRequest(result.ErrorMessage);

        return CreatedAtAction(nameof(Get), new { id = result.Data?.Id }, result.Data);
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
