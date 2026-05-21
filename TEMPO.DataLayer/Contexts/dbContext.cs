using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TEMPO.DataLayer.Entities;

namespace TEMPO.DataLayer.Contexts;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<AppUser>(options)
{
  public DbSet<TimeEntry> TimeEntries { get; set; } = null!;
  public DbSet<Project> Projects { get; set; } = null!;
  public DbSet<AppUser> AppUsers { get; set; } = null!;
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<TimeEntry>()
     .HasOne(te => te.Employee)
     .WithMany(u => u.TimeEntries)
     .HasForeignKey(te => te.EmployeeId)
     .OnDelete(DeleteBehavior.Cascade);

    modelBuilder.Entity<TimeEntry>()
     .HasOne(te => te.Project)
     .WithMany(p => p.TimeEntries)
     .HasForeignKey(te => te.ProjectId)
     .OnDelete(DeleteBehavior.Cascade);
  }
}