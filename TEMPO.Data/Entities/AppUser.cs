using Microsoft.AspNetCore.Identity;

namespace TEMPO.Data.Entities;
public class AppUser : IdentityUser
{
  public ICollection<TimeEntry> TimeEntries { get; set; } = new List<TimeEntry>();
  public ICollection<Report> Reports {get; set; } = new List<Report>();
}