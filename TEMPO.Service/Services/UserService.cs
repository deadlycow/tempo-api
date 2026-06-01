using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using TEMPO.Data.Entities;
using TEMPO.Service.Interfaces;
using TEMPO.Service.Factories;
using TEMPO.Domain.Common;
using TEMPO.Service.Command;
using TEMPO.Contracts.Dtos;

namespace TEMPO.Service.Services;

public class UserService(UserManager<AppUser> userManager) : IUserService
{
  private readonly UserManager<AppUser> _userManager = userManager;

  public async Task<ServiceResult<UserResponse>> GetByEmailAsync(string email)
  {
    if (string.IsNullOrWhiteSpace(email))
      throw new ArgumentException("Email cannot be null or empty.", nameof(email));

    var user = await _userManager.Users
    .FirstOrDefaultAsync(u => u.Email == email);

    if (user == null)
      return ServiceResult<UserResponse>.Failure("User not found.");

    return ServiceResult<UserResponse>.SuccessResult(UserFactory.ToResponse(user));
  }
  public async Task<ServiceResult<IEnumerable<UserResponse>>> GetAllAsync()
  {
    var users = await _userManager.Users.ToListAsync();

    if (users == null || users.Count == 0)
      return ServiceResult<IEnumerable<UserResponse>>.Failure("No users found.");

    var userModels = UserFactory.ToResponseList(users);
    return ServiceResult<IEnumerable<UserResponse>>.SuccessResult(userModels);
  }

  public async Task<IdentityResult> DeleteAsync(string id)
  {
    if (string.IsNullOrWhiteSpace(id))
      throw new ArgumentException("ID cannot be null or empty.", nameof(id));

    var user = await _userManager.Users
    .FirstOrDefaultAsync(u => u.Id == id);

    if (user == null)
      return IdentityResult.Failed(new IdentityError
      {
        Code = "404",
        Description = "User not found."
      });

    return await _userManager.DeleteAsync(user);
  }

  public async Task<IdentityResult> UpdateAsync(UpdateUserCommand command)
  {
    ArgumentNullException.ThrowIfNull(command);
    if (string.IsNullOrWhiteSpace(command.Id))
      throw new ArgumentException("ID is required.", nameof(command));

    var user = await _userManager.FindByIdAsync(command.Id);

    if (user == null)
      return IdentityResult.Failed(new IdentityError
      {
        Code = "404",
        Description = "User not found."
      });

    var actions = new List<Func<Task<IdentityResult?>>>();

    if (!string.IsNullOrWhiteSpace(command.UserName) && command.UserName != user.UserName)
      actions.Add(async () => await _userManager.SetUserNameAsync(user, command.UserName));

    if (!string.IsNullOrWhiteSpace(command.Email) && command.Email != user.Email)
      actions.Add(async () => await _userManager.SetEmailAsync(user, command.Email));

    if (!string.IsNullOrWhiteSpace(command.PhoneNumber) && command.PhoneNumber != user.PhoneNumber)
      actions.Add(async () => await _userManager.SetPhoneNumberAsync(user, command.PhoneNumber));

    foreach (var act in actions)
    {
      var res = await act();
      if (res != null && !res.Succeeded)
        return res;
    }

    return await _userManager.UpdateAsync(user);
  }
}