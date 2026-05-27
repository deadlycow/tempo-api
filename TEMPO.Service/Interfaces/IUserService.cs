using Microsoft.AspNetCore.Identity;
using TEMPO.Domain.Common;
using TEMPO.Service.Command;
using TEMPO.Contracts.Dtos;

namespace TEMPO.Service.Interfaces;

public interface IUserService
{
  Task<ServiceResult<UserResponse>> GetByEmailAsync(string email);
  Task<ServiceResult<IEnumerable<UserResponse>>> GetAllAsync();
  Task<IdentityResult> DeleteAsync(string id);
  Task<IdentityResult> UpdateAsync(UpdateUserCommand command);
}