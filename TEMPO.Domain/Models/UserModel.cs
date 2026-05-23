using System.ComponentModel.DataAnnotations;

namespace TEMPO.Domain.Models;

public class UserModel
{
  public string? UserName { get; set; }
  [EmailAddress]
  public string? Email { get; set; }
  [Phone]
  public string? PhoneNumber { get; set; }
}