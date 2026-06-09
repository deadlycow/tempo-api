using Microsoft.AspNetCore.Identity;

namespace TEMPO.Data.Entities;
public class AppUser : IdentityUser
{
  public ICollection<TimeEntry> TimeEntries { get; set; } = new List<TimeEntry>();
  public ICollection<WeeklyReport> WeeklyReports {get; set; } = new List<WeeklyReport>();
}