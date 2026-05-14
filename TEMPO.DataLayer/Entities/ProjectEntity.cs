namespace TEMPO.DataLayer.Entities;
public class ProjectEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public ICollection<EmployeeProjectEntity> EmployeeProjects { get; set; } = new List<EmployeeProjectEntity>();
}