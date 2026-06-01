using System.ComponentModel.DataAnnotations;

namespace TEMPO.Contracts.Dtos;

public record DeleteUserRequest
{
  public required string Id { get; set; }
}

public record GetUserRequest
{
  [EmailAddress]
  public required string Email { get; set; }
}

public record UpdateUserRequest
{
  public required string Id { get; set; }
  public string? UserName { get; set; }
  public string? Email { get; set; }
  public string? PhoneNumber { get; set; }
}