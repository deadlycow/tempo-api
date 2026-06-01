using System.ComponentModel.DataAnnotations;

namespace TEMPO.Contracts.Dtos;

public record CreateProjectRequest
{
  public required string Name { get; set; }
  public string? Description { get; set; }
  public DateTime StartDate { get; set; }
  public DateTime? EndDate { get; set; }
}

public record GetProjectRequest
{
  public required Guid Id { get; set; }
  public bool IncludeTimeEntries { get; init; } = false;
}

public record DeleteProjectRequest
{
  [Required]
  public required Guid Id { get; set; }
}

public record UpdateProjectRequest
{
  public required Guid Id { get; set; }
  public required string Name { get; set; }
  public string? Description { get; set; }
  public required DateTime StartDate { get; set; }
  public DateTime? EndDate { get; set; }
}