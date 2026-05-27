using Microsoft.AspNetCore.Mvc;
using TEMPO.Contracts.Dtos;
using TEMPO.Service.Command;
using TEMPO.Service.Interfaces;

namespace TEMPO.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserResponse>> Get([FromQuery] GetUserRequest request)
    {
        var user = await userService.GetByEmailAsync(request.Email);

        if (!user.Success)
            return NotFound(new { Message = user.ErrorMessage });

        return Ok(user.Data);
    }
    [HttpGet("all")]
    [ProducesResponseType(typeof(List<UserResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<UserResponse>>> GetAll()
    {
        var users = await userService.GetAllAsync();

        if (!users.Success)
            return NotFound(new { Message = users.ErrorMessage });

        return Ok(users.Data);
    }
    
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromQuery] DeleteUserRequest request)
    {
        var result = await userService.DeleteAsync(request.Id);
        if (!result.Succeeded)
            return NotFound(result.Errors);

        return NoContent();
    }
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update([FromQuery] UpdateUserRequest request)
    {
        var result = await userService.UpdateAsync(new UpdateUserCommand
        {
            Id = request.Id,
            UserName = request.UserName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber
        });

        if (!result.Succeeded)
            return NotFound(result.Errors);

        return Ok(new { Message = $"Value with ID {request.Id} updated successfully!" });
    }
}