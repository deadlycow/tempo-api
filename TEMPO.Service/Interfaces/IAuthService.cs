using Microsoft.AspNetCore.Identity;
using TEMPO.Contracts.Dtos;
using TEMPO.Domain.Common;
using TEMPO.Service.Command;

namespace TEMPO.Service.Interfaces;

public interface IAuthService
{
  Task<ServiceResult<AuthResponse>> LoginAsync(LoginRequest request);
  Task<IdentityResult> CreateAsync(CreateUserCommand command);
}