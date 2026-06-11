namespace TEMPO.Contracts.Dtos;

public record ReportRequest
{
    public required DateOnly Date { get; init; }
}