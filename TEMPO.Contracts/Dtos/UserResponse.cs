namespace TEMPO.Contracts.Dtos;
public record UserResponse
{
  public string? UserName { get; init; }
  public string? Email { get; init; }
  public string? PhoneNumber { get; init; }
  public string? Role { get; init;}
}