namespace TelemetryService.Dtos;

public class CreateTelemetryDto
{
    public int SensorId { get; set; }
    public double Value { get; set; }
    public string Unit { get; set; } = string.Empty;
}