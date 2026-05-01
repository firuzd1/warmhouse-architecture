namespace TelemetryService.Modrls;

public class TelemetryRecord
{
    public int Id { get; set; }
    public int SensorId { get; set; }
    public double Value { get; set; }
    public string Unit { get; set; } = string.Empty;
    public DateTime RecordedAt { get; set; }
}