using Microsoft.AspNetCore.Mvc;
using TEMPO.Api.Dtos;
using TEMPO.ServiceLayer.Services;

namespace TEMPO.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TimeEntryController(TimeEntryService timeEntryService) : ControllerBase
{
    private readonly TimeEntryService _timeEntryService = timeEntryService;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Get()
    {
        return Ok(new { Message = "Hello from TimeEntryController!" });
    }
    [HttpGet("all")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetAll()
    {
        return Ok(new { Message = "Hello from TimeEntryController!" });
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post(CreateTimeEntryRequest request)
    {
        var result = await _timeEntryService.CreateTimeEntryAsync(new CreateTimeEntryCommand
        {
            EmployeeId = request.EmployeeId,
            Date = request.Date,
            HoursWorked = request.HoursWorked,
            Description = request.Description,
            ProjectId = request.ProjectId
        });
        return CreatedAtAction(nameof(Get), new { id = 1 }, new { Message = "Value created successfully!" });
    }
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromQuery] DeleteTimeEntryRequest id)
    {
        return Ok(new { Message = $"Value deleted successfully for ID: {id}" });
    }
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put([FromBody] UpdateTimeEntryRequest request)
    {
        // var result = await _timeEntryService.UpdateTimeEntryAsync(new UpdateTimeEntryCommand
        // {
        //     Id = id,
        //     EmployeeId = request.EmployeeId,
        //     Date = request.Date,
        //     HoursWorked = request.HoursWorked,
        //     Description = request.Description,
        //     ProjectId = request.ProjectId
        // });
        return Ok(new { Message = "Value updated successfully!" });
    }
}
