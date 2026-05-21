using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using TEMPO.DataLayer.Entities;
using TEMPO.ServiceLayer.Interfaces;
using TEMPO.ServiceLayer.Factories;
using TEMPO.Domain.Models;
using TEMPO.Domain.Common;
using TEMPO.ServiceLayer.Command;

namespace TEMPO.ServiceLayer.Services;

public class UserService(UserManager<AppUser> userManager) : IUserService
{
  private readonly UserManager<AppUser> _userManager = userManager;

  public async Task<ServiceResult<UserModel>> Get(string email)
  {
    if (string.IsNullOrWhiteSpace(email))
      throw new ArgumentException("Email cannot be null or empty.", nameof(email));

    var user = await _userManager.Users
    .FirstOrDefaultAsync(u => u.Email == email);

    if (user == null)
      return ServiceResult<UserModel>.Failure("User not found.");

    return ServiceResult<UserModel>.SuccessResult(UserFactory.ToModel(user));
  }
  public async Task<ServiceResult<List<UserModel>>> GetAll()
  {
    var users = await _userManager.Users.ToListAsync();

    if (users == null || users.Count == 0)
      return ServiceResult<List<UserModel>>.Failure("No users found.");

    var userModels = users.Select(UserFactory.ToModel).ToList();
    return ServiceResult<List<UserModel>>.SuccessResult(userModels);
  }

  public async Task<IdentityResult> Create(CreateUserCommand command)
  {
    ArgumentNullException.ThrowIfNull(command);

    var existingUser = await _userManager.FindByEmailAsync(command.Email);
    if (existingUser != null)
      return IdentityResult.Failed(new IdentityError
      {
        Code = "UserAlreadyExists",
        Description = "A user with this email already exists."
      });

    var user = UserFactory.ToEntity(command);

    var result = await _userManager.CreateAsync(user, command.Password ?? "DefaultPassword123!");
    if (!result.Succeeded)
      return result;

    if (!string.IsNullOrWhiteSpace(command.Role.ToString()))
    {
      await _userManager.AddToRoleAsync(user, command.Role.ToString());
    }
    return result;
  }

  public async Task<IdentityResult> Delete(string id)
  {
    if (string.IsNullOrWhiteSpace(id))
      throw new ArgumentException("ID cannot be null or empty.", nameof(id));

    var user = await _userManager.Users
    .FirstOrDefaultAsync(u => u.Id == id);

    if (user == null)
      return IdentityResult.Failed(new IdentityError
      {
        Code = "UserNotFound",
        Description = "User not found."
      });

    return await _userManager.DeleteAsync(user);
  }

  public async Task<IdentityResult> Update(UpdateUserCommand command)
  {
    ArgumentNullException.ThrowIfNull(command);
    if (string.IsNullOrWhiteSpace(command.Id))
      throw new ArgumentException("ID is required.", nameof(command));

    var user = await _userManager.FindByIdAsync(command.Id);

    if (user == null)
      return IdentityResult.Failed(new IdentityError
      {
        Code = "UserNotFound",
        Description = "User not found."
      });

    var actions = new List<Func<Task<IdentityResult?>>>();

    if (!string.IsNullOrWhiteSpace(command.UserName) && command.UserName != user.UserName)
      actions.Add(async () => await _userManager.SetUserNameAsync(user, command.UserName));

    if (!string.IsNullOrWhiteSpace(command.Email) && command.Email != user.Email)
      actions.Add(async () => await _userManager.SetEmailAsync(user, command.Email));

    if (!string.IsNullOrWhiteSpace(command.PhoneNumber) && command.PhoneNumber != user.PhoneNumber)
      actions.Add(async () => await _userManager.SetPhoneNumberAsync(user, command.PhoneNumber));

    // Run actions and return first failure
    foreach (var act in actions)
    {
      var res = await act();
      if (res != null && !res.Succeeded)
        return res;
    }

    return await _userManager.UpdateAsync(user);
  }


}