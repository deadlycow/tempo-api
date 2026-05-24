using System.ComponentModel.DataAnnotations;
using TEMPO.ServiceLayer.Common.Enum;

namespace TEMPO.ServiceLayer.Command;

public class CreateUserCommand
{
  public required string UserName { get; set; }
  public required string Email { get; set; }
  public required string Password { get; set; }
  public string? PhoneNumber { get; set; }
  public UserRole Role { get; set; } = UserRole.User;
}
public class UpdateUserCommand
{
  [Required]
  public required string Id { get; set; }
  public string? UserName { get; set; }
  public string? Email { get; set; }
  public string? PhoneNumber { get; set; }
}
