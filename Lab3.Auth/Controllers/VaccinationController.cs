using Lab3.Auth.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab3.Auth.Controllers;

[ApiController]
[Route("api")]
public class VaccinationController : ControllerBase
{
    private readonly IAppointmentService _appointments;

    public VaccinationController(IAppointmentService appointments) => _appointments = appointments;

    public record CreateAppointmentRequest(string Username, DateOnly Date, string Vaccine, string? Note);

    [HttpPost("appointments")]
    public IActionResult Create([FromBody] CreateAppointmentRequest req)
    {
        var result = _appointments.Create(req.Username, req.Date, req.Vaccine, req.Note);
        return result.Success ? Created("", result) : BadRequest(result);
    }

    [HttpGet("appointments/{username}")]
    public IActionResult GetByUser([FromRoute] string username) =>
        Ok(new { Username = username, Appointments = _appointments.GetByUser(username) });

    [HttpGet("appointments")]
    public IActionResult GetAll() => Ok(new { Appointments = _appointments.GetAll() });
}

