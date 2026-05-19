using System.ComponentModel.DataAnnotations;

namespace TEMPO.Api.Dtos;

public class CreateUserRequest
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