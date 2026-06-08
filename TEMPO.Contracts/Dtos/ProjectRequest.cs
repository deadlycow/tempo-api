using System.ComponentModel.DataAnnotations;

namespace TEMPO.Contracts.Dtos;

public record CreateProjectRequest
{
  public required string Name { get; init; }
  public string? Description { get; init; }
  public DateTime StartDate { get; init; }
  public DateTime? EndDate { get; init; }
}

public record GetProjectRequest
{
  public required Guid Id { get; init; }
  public bool IncludeTimeEntries { get; init; } = false;
}

public record DeleteProjectRequest
{
  [Required]
  public required Guid Id { get; init; }
}

public record UpdateProjectRequest
{
  public required Guid Id { get; init; }
  public required string Name { get; init; }
  public string? Description { get; init; }
  public required DateTime StartDate { get; init; }
  public DateTime? EndDate { get; init; }
}