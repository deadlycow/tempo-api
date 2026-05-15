using Microsoft.AspNetCore.Identity;

namespace TEMPO.DataLayer.Entities;
public class TempoUser : IdentityUser
{
  public ICollection<TimeReport> TimeReports { get; set; } = new List<TimeReport>();
}