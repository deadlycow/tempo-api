using Microsoft.AspNetCore.Identity;
using TEMPO.Domain.Models;

namespace TEMPO.ServiceLayer.Interfaces;

public interface IUserService
{
  Task<UserModel> Get(string id);
  Task<IdentityResult> Create(UserModel user);
}