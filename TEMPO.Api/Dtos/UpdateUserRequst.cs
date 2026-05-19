using System.ComponentModel.DataAnnotations;

namespace TEMPO.Api.Dtos;

public class UpdateUserRequest
{
  [Required]
  public required string Id { get; set; }
  public string? UserName { get; set; }
  public string? Email { get; set; }
  public string? PhoneNumber { get; set; }
}