using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TEMPO.DataLayer.Entities;

namespace TEMPO.DataLayer.Contexts;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<TempoUser>(options)
{
  public DbSet<TimeReport> TimeReports { get; set; } = null!;
  public DbSet<Project> Projects { get; set; } = null!;
  public DbSet<TempoUser> TempoUsers { get; set; } = null!;
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<TimeReport>()
     .HasOne(tr => tr.Employee)
     .WithMany(u => u.TimeReports)
     .HasForeignKey(tr => tr.EmployeeId)
     .OnDelete(DeleteBehavior.Cascade);
  }
}