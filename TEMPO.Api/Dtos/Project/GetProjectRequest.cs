namespace TEMPO.Api.Dtos.Project;

public record GetProjectRequest
{
  public Guid Id { get; set; }
}

public record DeleteProjectRequest
{
  public Guid Id { get; set; }
}