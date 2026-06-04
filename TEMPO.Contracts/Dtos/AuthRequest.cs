using System.ComponentModel.DataAnnotations;
using TEMPO.Domain.Common.Enum;
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
  public required string Name { get; init; }
  [EmailAddress]
  public required string Email { get; init; }
  [StringLength(100, MinimumLength = 6)]
  public required string Password { get; init; }
  public string? PhoneNumber { get; init; }
  public required string Role { get; init; }
}