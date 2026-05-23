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
  [Required]
  public required Guid Id { get; set; }
}

public record DeleteProjectRequest
{
  [Required]
  public required Guid Id { get; set; }
}

public record UpdateProjectRequest
{
  [Required]
  public required Guid Id { get; set; }
  [Required]
  public required string Name { get; set; }
  public string? Description { get; set; }
  public DateTime? StartDate { get; set; }
  public DateTime? EndDate { get; set; }
}