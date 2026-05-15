namespace TEMPO.DataLayer.Entities;
public class Project
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public ICollection<TimeReport> TimeReports { get; set; } = new List<TimeReport>();
    public ICollection<TempoUser> Employees { get; set; } = new List<TempoUser>();
}