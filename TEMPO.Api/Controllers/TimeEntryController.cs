using Microsoft.AspNetCore.Mvc;
using TEMPO.Api.Dtos;
using TEMPO.ServiceLayer.Services;
using TEMPO.ServiceLayer.Command;
using TEMPO.Domain.Models;

namespace TEMPO.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TimeEntryController(TimeEntryService timeEntryService) : ControllerBase
{
    private readonly TimeEntryService _timeEntryService = timeEntryService;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get([FromQuery] GetTimeEntryRequest request)
    {
        var result = await _timeEntryService.GetByIdAsync(new GetTimeEntryCommand { Id = request.Id });
        if (!result.Success)
            return NotFound(result.ErrorMessage);
        return Ok(result.Data);
    }
    [HttpGet("allByUserId")]
    [ProducesResponseType(typeof(IEnumerable<TimeEntryModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAll([FromQuery] GetAllTimeEntryByUserIdRequest request)
    {
        var timeEntries = await _timeEntryService.GetAllByUserIdAsync(new GetTimeEntryCommand { Id = request.Id });
        if (timeEntries == null || !timeEntries.Success)
            return NotFound(timeEntries?.ErrorMessage ?? "No time entries found for the user.");
        return Ok(timeEntries);
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateTimeEntryRequest), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post(CreateTimeEntryRequest request)
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
    public async Task<IActionResult> Delete([FromQuery] DeleteTimeEntryRequest id)
    {
        var result = await _timeEntryService.DeleteAsync(id.Id);

        if (!result.Success)
            return NotFound(result.ErrorMessage);

        return NoContent();
    }
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([FromBody] UpdateTimeEntryRequest request)
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
