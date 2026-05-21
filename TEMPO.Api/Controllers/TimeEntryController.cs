using Microsoft.AspNetCore.Mvc;
using TEMPO.Api.Dtos.TimeReport;
using TEMPO.ServiceLayer.Services;

namespace TEMPO.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TimeEntryController(TimeEntryService timeEntryService) : ControllerBase
{
    private readonly TimeEntryService _timeEntryService = timeEntryService;

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { Message = "Hello from TimeEntryController!" });
    }

    [HttpPost]
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
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] object value)
    {
        return Ok(new { Message = $"Value updated successfully for ID: {id}" });
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return Ok(new { Message = $"Value deleted successfully for ID: {id}" });
    }
}
