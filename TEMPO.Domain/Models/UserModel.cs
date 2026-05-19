using System.ComponentModel.DataAnnotations;

namespace TEMPO.Domain.Models;

public class UserModel
{
  [Required]
  [StringLength(25, MinimumLength = 3)]
  public required string UserName { get; set; }
  [Required]
  [EmailAddress]
  public required string Email { get; set; }
}