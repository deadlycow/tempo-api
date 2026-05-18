using Microsoft.AspNetCore.Mvc;
using TEMPO.Domain.Models;
using TEMPO.ServiceLayer.Interfaces;

namespace TEMPO.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { Message = "Hello from UserController!" });
    }
    [HttpPost]
    public async Task<IActionResult> Post(UserModel user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await userService.Create(user);
        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return Ok(new { Message = "User created successfully!" });
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