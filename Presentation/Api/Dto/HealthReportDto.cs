namespace Api.Dto;

public class HealthReportDto
{
    public string Status { get; set; }
    public TimeSpan TotalDuration { get; set; }
    public IDictionary<string, HealthReportEntryDto> Entries { get; set; }
}