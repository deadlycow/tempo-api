using Microsoft.AspNetCore.Identity;

namespace TEMPO.DataLayer.Entities;
public class AppUser : IdentityUser
{
  public ICollection<TimeEntry> TimeEntries { get; set; } = new List<TimeEntry>();
}