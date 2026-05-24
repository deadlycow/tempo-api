using Microsoft.AspNetCore.Identity;
using TEMPO.Domain.Models;
using TEMPO.Domain.Common;
using TEMPO.ServiceLayer.Command;

namespace TEMPO.ServiceLayer.Interfaces;

public interface IUserService
{
  Task<ServiceResult<UserModel>> GetByEmailAsync(string email);
  Task<ServiceResult<IEnumerable<UserModel>>> GetAllAsync();
  Task<IdentityResult> CreateAsync(CreateUserCommand command);
  Task<IdentityResult> DeleteAsync(string id);
  Task<IdentityResult> UpdateAsync(UpdateUserCommand command);
}