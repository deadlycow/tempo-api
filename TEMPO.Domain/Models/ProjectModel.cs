namespace TEMPO.Domain.Models;

public class ProjectModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public IEnumerable<TimeEntryModel> TimeEntries { get; set; } = [];
}