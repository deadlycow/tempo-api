using TEMPO.Domain.Common.Enum;

namespace TEMPO.Service.Command;

public record UserCommand
{
  public string? UserName { get; init; }
  public string? PhoneNumber { get; init; }
}
public record CreateUserCommand : UserCommand
{
  public required string Password { get; init; }
  public required string Email { get; init; }
  public required UserRole Role { get; init; }
}
public record UpdateUserCommand : UserCommand
{
  public required string Id { get; init; }
  public string? Email { get; init; }
  public UserRole? Role { get; init; }
}
