using Microsoft.AspNetCore.Mvc;
using TEMPO.Api.Dtos;
using TEMPO.Domain.Models;
using TEMPO.ServiceLayer.Command;
using TEMPO.ServiceLayer.Interfaces;

namespace TEMPO.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(UserModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserModel>> Get([FromQuery] GetUserRequest request)
    {
        var user = await userService.Get(request.Email);

        if (!user.Success)
            return NotFound(new { Message = user.ErrorMessage });

        return Ok(user.Data);
    }
    [HttpGet("all")]
    [ProducesResponseType(typeof(List<UserModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<UserModel>>> GetAll()
    {
        var users = await userService.GetAll();

        if (!users.Success)
            return NotFound(new { Message = users.ErrorMessage });

        return Ok(users.Data);
    }
    [HttpPost]
    [ProducesResponseType(typeof(CreateUserRequest), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Post(CreateUserRequest request)
    {
        var command = new CreateUserCommand
        {
            UserName = request.UserName,
            Email = request.Email,
            Password = request.Password
        };

        var result = await userService.Create(command);
        if (!result.Succeeded)
            return NotFound(result.Errors);

        return CreatedAtAction(nameof(Get), new { Message = $"User created successfully!" });
    }
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromQuery] DeleteUserRequest request)
    {
        var result = await userService.Delete(request.Id);
        if (!result.Succeeded)
            return NotFound(result.Errors);

        return NoContent();
    }
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Put([FromQuery] UpdateUserRequest request)
    {
        var command = new UpdateUserCommand
        {
            Id = request.Id,
            UserName = request.UserName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber
        };

        var result = await userService.Update(command);
        if (!result.Succeeded)
            return NotFound(result.Errors);

        return Ok(new { Message = $"Value with ID {request.Id} updated successfully!" });
    }
}