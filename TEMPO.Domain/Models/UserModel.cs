using System.ComponentModel.DataAnnotations;

namespace TEMPO.Domain.Models;

public class UserModel
{
  [Required]
  [StringLength(25, MinimumLength = 3)]
  public string UserName { get; set; } = string.Empty;
  [Required]
  [EmailAddress]
  public string Email { get; set; } = string.Empty;
}