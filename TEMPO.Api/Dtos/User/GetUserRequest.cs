using System.ComponentModel.DataAnnotations;

namespace TEMPO.Api.Dtos.User;

public class GetUserRequest
{
    [Required]
    [EmailAddress]
  public required string Email { get; set; }
}