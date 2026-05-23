namespace TEMPO.ServiceLayer.Command;
public class CreateProjectCommand
{
  public required string Name { get; set; }
  public string? Description { get; set; }
  public DateTime StartDate { get; set; }
  public DateTime? EndDate { get; set; }
}

public class UpdateProjectCommand
{
  public required Guid Id { get; set; }
  public required string Name { get; set; }
  public string? Description { get; set; }
  public DateTime? StartDate { get; set; }
  public DateTime? EndDate { get; set; }
}