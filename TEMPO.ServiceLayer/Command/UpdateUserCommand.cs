using System.ComponentModel.DataAnnotations;

namespace TEMPO.ServiceLayer.Command;

public class UpdateUserCommand
{
  [Required]
  public required string Id { get; set; }
  public string? UserName { get; set; }
  public string? Email { get; set; }
  public string? PhoneNumber { get; set; }
}