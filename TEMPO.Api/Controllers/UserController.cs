using Microsoft.AspNetCore.Mvc;

namespace TEMPO.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { Message = "Hello from UserController!" });
    }
    [HttpPost]
    public IActionResult Post([FromBody] object value)
    {
        return CreatedAtAction(nameof(Get), new { id = 1 }, new { Message = "Value created successfully!" });
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return Ok(new { Message = $"Value with ID {id} deleted successfully!" });
    }
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] object value)
    {
        return Ok(new { Message = $"Value with ID {id} updated successfully!" });
    }
}