using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TEMPO.Data.Entities;

namespace TEMPO.Data.Contexts;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<AppUser>(options)
{
  public DbSet<TimeEntry> TimeEntries { get; set; } = null!;
  public DbSet<Project> Projects { get; set; } = null!;
  public DbSet<AppUser> AppUsers { get; set; } = null!;
  public DbSet<Report> Reports {get; set; } = null!;
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Report>()
    .HasOne(r => r.Employee)
    .WithMany(u => u.Reports)
    .HasForeignKey(wr => wr.EmployeeId)
    .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<TimeEntry>()
    .HasOne(te => te.Report)
    .WithMany(r => r.TimeEntry)
    .HasForeignKey(te => te.ReportId)
    .OnDelete(DeleteBehavior.NoAction);

    modelBuilder.Entity<TimeEntry>()
    .HasOne(te => te.Employee)
    .WithMany(u => u.TimeEntries)
    .HasForeignKey(te => te.EmployeeId)
    .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<TimeEntry>()
    .HasOne(te => te.Project)
    .WithMany(p => p.TimeEntries)
    .HasForeignKey(te => te.ProjectId)
    .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<TimeEntry>()
    .HasIndex(te => new { te.ProjectId, te.EmployeeId, te.Date })
    .IsUnique();

    modelBuilder.Entity<Project>()
    .HasQueryFilter(p => !p.IsDeleted);
  }
}