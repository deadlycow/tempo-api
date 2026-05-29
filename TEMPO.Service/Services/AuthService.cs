using Microsoft.AspNetCore.Identity;
using TEMPO.Contracts.Dtos;
using TEMPO.Data.Entities;
using TEMPO.Domain.Common;
using TEMPO.Service.Command;
using TEMPO.Service.Factories;
using TEMPO.Service.Interfaces;

namespace TEMPO.Service.Services;

public class AuthService(UserManager<AppUser> userManager, ITokenService TokenService) : IAuthService
{
  private readonly UserManager<AppUser> _userManager = userManager;
  private readonly ITokenService _tokenService = TokenService;

  public async Task<ServiceResult<AuthResponse>> LoginAsync(LoginRequest request)
  {
    var user = await _userManager.FindByEmailAsync(request.Email);
    if (user == null)
      return ServiceResult<AuthResponse>.Failure("Invalid credentials");

    var passwordValid = await _userManager.CheckPasswordAsync(user, request.Password);

    if (!passwordValid)
      return ServiceResult<AuthResponse>.Failure("Invalid credentials");

    var roles = await _userManager.GetRolesAsync(user);

    var token = _tokenService.CreateToken(user, roles);

    return ServiceResult<AuthResponse>.SuccessResult(new AuthResponse
    {
      AccessToken = token,
      Email = user.Email!,
      UserId = user.Id,
      UserName = user.UserName,
      Role = roles.FirstOrDefault() ?? "Employee",
      ExpiresAt = DateTime.UtcNow.AddHours(2)
    });
  }
  public async Task<IdentityResult> CreateAsync(CreateUserCommand command)
  {
    // ArgumentNullException.ThrowIfNull(command);

    var existingUser = await _userManager.FindByEmailAsync(command.Email);
    if (existingUser != null)
      return IdentityResult.Failed(new IdentityError
      {
        Code = "409",
        Description = "Email already exists."
      });

    var user = UserFactory.ToEntity(command);

    var result = await _userManager.CreateAsync(user, command.Password ?? "DefaultPassword123!");
    if (!result.Succeeded)
      return result;

    await _userManager.AddToRoleAsync(user, command.Role.ToString());

    return result;
  }
}
