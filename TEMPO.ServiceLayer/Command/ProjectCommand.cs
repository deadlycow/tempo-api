namespace TEMPO.ServiceLayer.Command;

public record CreateProjectCommand
{
  public required string Name { get; init; }
  public required DateTime StartDate { get; init; }
  public DateTime? EndDate { get; init; }
  public string? Description { get; init; }
}
public record UpdateProjectCommand
{
  public required Guid Id { get; init; }
  public string? Name { get; init; }
  public DateTime? StartDate { get; init; }
  public DateTime? EndDate { get; init; }
  public string? Description { get; init; }
}