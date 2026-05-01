using Microsoft.AspNetCore.Mvc;
using TelemetryService.Dtos;
using TelemetryService.Modrls;

namespace TelemetryService.Controllers;

[ApiController]
[Route("api/v1/telemetry")]
public class TelemetryController : ControllerBase
{
    private static readonly List<TelemetryRecord> Records = new();
    private static int _nextId = 1;

    [HttpGet("{sensorId}")]
    public IActionResult GetBySensor(int sensorId)
    {
        var records = Records.Where(r => r.SensorId == sensorId).ToList();
        return Ok(records);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateTelemetryDto dto)
    {
        var record = new TelemetryRecord
        {
            Id = _nextId++,
            SensorId = dto.SensorId,
            Value = dto.Value,
            Unit = dto.Unit,
            RecordedAt = DateTime.UtcNow
        };
        Records.Add(record);
        return CreatedAtAction(nameof(GetBySensor), new { sensorId = record.SensorId }, record);
    }
}