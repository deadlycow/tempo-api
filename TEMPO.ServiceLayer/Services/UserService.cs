using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using TEMPO.DataLayer.Entities;
using TEMPO.ServiceLayer.Interfaces;
using TEMPO.ServiceLayer.Factories;
using TEMPO.Domain.Models;
using TEMPO.Domain.Common;

namespace TEMPO.ServiceLayer.Services;

public class UserService(UserManager<TempoUser> userManager) : IUserService
{
  private readonly UserManager<TempoUser> _userManager = userManager;

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

  public async Task<IdentityResult> Create(UserModel user)
  {
    ArgumentNullException.ThrowIfNull(user);

    if (string.IsNullOrWhiteSpace(user.UserName))
    {
      return IdentityResult.Failed(new IdentityError
      {
        Code = "UserNameRequired",
        Description = "Username cannot be empty."
      });
    }
    return await _userManager.CreateAsync(UserFactory.ToEntity(user), password: "DefaultPassword123!"); // Example of creating a user with a default password
  }

}