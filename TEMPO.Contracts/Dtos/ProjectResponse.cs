namespace TEMPO.Contracts.Dtos;

public record ProjectResponse
{
  public Guid Id { get; init; }
  public string Name { get; init; } = null!;
  public string? Description { get; init; }
  public DateTime StartDate { get; init; }
  public DateTime? EndDate { get; init; }
  public IEnumerable<TimeEntryResponse> TimeEntries { get; init; } = [];
}