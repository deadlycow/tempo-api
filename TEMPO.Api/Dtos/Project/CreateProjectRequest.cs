using System.ComponentModel.DataAnnotations;

namespace TEMPO.Api.Dtos.Project;

public record CreateProjectRequest
{
  [Required]
  public required string Name { get; set; }
  public string? Description { get; set; }
  public DateTime StartDate { get; set; }
  public DateTime? EndDate { get; set; }
}