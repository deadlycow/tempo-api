using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TEMPO.Contracts.Dtos;

public record LoginRequest
{
  [EmailAddress]
  public required string Email { get; init; }
  public required string Password { get; init; }
}

public record CreateUserRequest
{
  [StringLength(25, MinimumLength = 3)]
  public required string UserName { get; init; }
  [EmailAddress]
  public required string Email { get; init; }
  [StringLength(100, MinimumLength = 6)]
  public required string Password { get; init; }
  public string? PhoneNumber { get; init; }
}