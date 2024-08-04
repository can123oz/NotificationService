using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Api.Dto;

public static class HealthReportExtensions
{
    public static HealthReportDto ToDto(this HealthReport report)
    {
        return new HealthReportDto
        {
            Status = report.Status.ToString(),
            TotalDuration = report.TotalDuration,
            Entries = report.Entries.ToDictionary(
                entry => entry.Key,
                entry => new HealthReportEntryDto
                {
                    Status = entry.Value.Status.ToString(),
                    Description = entry.Value.Description,
                    Duration = entry.Value.Duration,
                    Data = entry.Value.Data.ToDictionary(k => k.Key, v => v.Value)
                })
        };
    }
}