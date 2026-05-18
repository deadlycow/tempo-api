using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using TEMPO.ServiceLayer.Interfaces;
using TEMPO.DataLayer.Entities;
using TEMPO.Domain.Models;
using TEMPO.ServiceLayer.Factories;

namespace TEMPO.ServiceLayer.Services;

public class UserService(UserManager<TempoUser> userManager) : IUserService
{
  private readonly UserManager<TempoUser> _userManager = userManager;

  public async Task<UserModel> Get(string id)
  {
    if (string.IsNullOrWhiteSpace(id))
      throw new ArgumentException("User ID cannot be null or empty.", nameof(id));
    
    var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
    return user != null ? UserFactory.ToModel(user) : null;
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