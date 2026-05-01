using DeviceService.Dtos;
using DeviceService.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeviceService.Controllers;

[ApiController]
[Route("api/v1/devices")]
public class DeviceController : ControllerBase
{
    private static readonly List<Device> Devices = new();
    private static int _nextId = 1;

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(Devices);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var device = Devices.FirstOrDefault(d => d.Id == id);
        if (device == null) return NotFound();
        return Ok(device);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateDeviceDto dto)
    {
        var device = new Device
        {
            Id = _nextId++,
            Name = dto.Name,
            Type = dto.Type,
            Location = dto.Location,
            Status = "active",
            CreatedAt = DateTime.UtcNow
        };
        Devices.Add(device);
        return CreatedAtAction(nameof(GetById), new { id = device.Id }, device);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] UpdateDeviceDto dto)
    {
        var device = Devices.FirstOrDefault(d => d.Id == id);
        if (device == null) return NotFound();
        device.Name = dto.Name ?? device.Name;
        device.Status = dto.Status ?? device.Status;
        device.Location = dto.Location ?? device.Location;
        return Ok(device);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var device = Devices.FirstOrDefault(d => d.Id == id);
        if (device == null) return NotFound();
        Devices.Remove(device);
        return NoContent();
    }
}