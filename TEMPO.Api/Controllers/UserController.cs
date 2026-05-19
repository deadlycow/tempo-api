using Microsoft.AspNetCore.Mvc;
using TEMPO.Api.Dtos;
using TEMPO.Domain.Models;
using TEMPO.ServiceLayer.Interfaces;

namespace TEMPO.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<UserModel>> Get([FromQuery] GetUserRequest request)
    {
        var user = await userService.Get(request.Email);

        if (!user.Success)
            return NotFound(new { Message = user.ErrorMessage });

        return Ok(user.Data);
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