using Microsoft.AspNetCore.Mvc;
using TEMPO.Contracts.Dtos;
using TEMPO.Service.Command;
using TEMPO.Service.Common.Enum;
using TEMPO.Service.Interfaces;

namespace TEMPO.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        private readonly IAuthService _authService = authService;
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] LoginRequest request)
        {
            var result = await _authService.LoginAsync(request);
            
            if (!result.Success)
                return Unauthorized(result.ErrorMessage);
                
            return Ok(result.Data);
        }
        [HttpPost("register")]
        [ProducesResponseType(typeof(CreateUserRequest), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateUserRequest request)
        {
            var result = await _authService.CreateAsync(new CreateUserCommand
            {
                UserName = request.UserName,
                Email = request.Email,
                Password = request.Password,
                Role = Enum.Parse<UserRole>(request.Role!)
            });

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return CreatedAtAction(nameof(UsersController.Get), new { Message = $"User created successfully!" });
        }
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            return Ok("logout");
        }
        [HttpPost("refreshtoken")]
        public IActionResult RefreshToken()
        {
            return Ok("new token");
        }
        [HttpPost("emailVerification")]
        public IActionResult EmailVerification()
        {
            return Ok("Email verificaton");
        }
        [HttpPost("passwordreset")]
        public IActionResult PasswordReset()
        {
            return Ok("password reset");
        }

    }
}