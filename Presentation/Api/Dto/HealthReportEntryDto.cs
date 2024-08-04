namespace Api.Dto;

public class HealthReportEntryDto
{
    public string Status { get; set; }
    public string Description { get; set; }
    public TimeSpan Duration { get; set; }
    public IDictionary<string, object> Data { get; set; }
}