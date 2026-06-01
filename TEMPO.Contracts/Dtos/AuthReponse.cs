namespace TEMPO.Contracts.Dtos;

public class AuthResponse
{
  public string AccessToken { get; init; } = null!;
  public string Email { get; init; } = null!;
  public string UserId { get; init; } = null!;
  public string? UserName { get; init; }
  public DateTime ExpiresAt { get; init; }
}