using Microsoft.AspNetCore.Identity;
using TEMPO.Domain.Models;
using TEMPO.Domain.Common;
using TEMPO.ServiceLayer.Command;

namespace TEMPO.ServiceLayer.Interfaces;

public interface IUserService
{
  Task<ServiceResult<UserModel>> Get(string email);
  Task<IdentityResult> Create(CreateUserCommand command);
  Task<IdentityResult> Delete(string id);
  Task<IdentityResult> Update(UpdateUserCommand command);
}