using TEMPO.ServiceLayer.Common.Enum;

namespace TEMPO.ServiceLayer.Command;

public record UserCommand
{
  public string? UserName { get; init; }
  public string? PhoneNumber { get; init; }
}
public record CreateUserCommand : UserCommand
{
  public required string Password { get; init; }
  public required string Email { get; init; }
  public UserRole Role { get; init; } = UserRole.User;
}
public record UpdateUserCommand : UserCommand
{
  public required string Id { get; init; }
  public string? Email { get; init; }
  public UserRole? Role { get; init; }
}
