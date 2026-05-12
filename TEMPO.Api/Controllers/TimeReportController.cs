using Microsoft.AspNetCore.Mvc;

namespace TEMPO.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TimeReportController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { Message = "Hello from TimeReportController!" });
    }

    [HttpPost]
    public IActionResult Post([FromBody] object value)
    {
        return CreatedAtAction(nameof(Get), new { id = 1 }, new { Message = "Value created successfully!" });
    }
}
