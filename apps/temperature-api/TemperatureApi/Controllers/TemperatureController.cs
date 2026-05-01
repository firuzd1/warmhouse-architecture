using Microsoft.AspNetCore.Mvc;

namespace TemperatureApi.Controllers;

[ApiController]
[Route("")]
public class TemperatureController : ControllerBase
{
    private readonly Random _random = new();

    private static readonly Dictionary<string, string> LocationToSensor = new()
    {
        { "Living Room", "1" },
        { "Bedroom", "2" },
        { "Kitchen", "3" }
    };

    private static readonly Dictionary<string, string> SensorToLocation = new()
    {
        { "1", "Living Room" },
        { "2", "Bedroom" },
        { "3", "Kitchen" }
    };

    [HttpGet("temperature")]
    public IActionResult GetTemperature([FromQuery] string? location, [FromQuery] string? sensorId)
    {
        if (string.IsNullOrEmpty(location) && string.IsNullOrEmpty(sensorId))
        {
            location = "Unknown";
            sensorId = "0";
        }

        if (string.IsNullOrEmpty(location))
        {
            location = SensorToLocation.GetValueOrDefault(sensorId!, "Unknown");
        }

        if (string.IsNullOrEmpty(sensorId))
        {
            sensorId = LocationToSensor.GetValueOrDefault(location, "0");
        }

        var temperature = Math.Round(_random.NextDouble() * 15 + 18, 1);

        return Ok(new
        {
            value = temperature,
            unit = "°C",
            timestamp = DateTime.UtcNow,
            location = location,
            status = "active",
            sensor_id = sensorId,
            sensor_type = "temperature",
            description = $"Temperature in {location}"
        });
    }
}