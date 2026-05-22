using System.ComponentModel.DataAnnotations;

namespace TEMPO.Api.Dtos;

public record CreateProjectRequest
{
  [Required]
  public required string Name { get; set; }
  public string? Description { get; set; }
  public DateTime StartDate { get; set; }
  public DateTime? EndDate { get; set; }
}

public record GetProjectRequest
{
  public Guid Id { get; set; }
}

public record DeleteProjectRequest
{
  public Guid Id { get; set; }
}

public record UpdateProjectRequest
{
  public required Guid Id { get; set; }
  public required string Name { get; set; }
  public string? Description { get; set; }
  public DateTime? StartDate { get; set; }
  public DateTime? EndDate { get; set; }
}