using Microsoft.AspNetCore.Identity;
using TEMPO.Domain.Models;
using TEMPO.Domain.Common;
namespace TEMPO.ServiceLayer.Interfaces;

public interface IUserService
{
  Task<ServiceResult<UserModel>> Get(string email);
  Task<IdentityResult> Create(UserModel user);
}