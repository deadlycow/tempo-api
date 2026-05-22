using System.ComponentModel.DataAnnotations;

namespace TEMPO.Api.Dtos;

public record CreateUserRequest
{
  [Required]
  [StringLength(25, MinimumLength = 3)]
  public required string UserName { get; set; }
  [Required]
  [EmailAddress]
  public required string Email { get; set; }
  [Required]
  [StringLength(100, MinimumLength = 6)]
  public required string Password { get; set; }
  public string? PhoneNumber { get; set; }
}

public record DeleteUserRequest
{
  public required string Id { get; set; }
}

public record GetUserRequest
{
    [Required]
    [EmailAddress]
  public required string Email { get; set; }
}

public record UpdateUserRequest
{
  [Required]
  public required string Id { get; set; }
  public string? UserName { get; set; }
  public string? Email { get; set; }
  public string? PhoneNumber { get; set; }
}