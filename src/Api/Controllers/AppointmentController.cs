using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Core.Entities;
using System.Collections.Generic;

namespace Api.Controllers
{
   [ApiController]
[Route("api/[controller]")]
[Authorize]
public class AppointmentController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    [HttpPost]
    public async Task<IActionResult> BookAppointment([FromBody] AppointmentRequestDto appointmentDto)
    {
        var appointment = await _appointmentService.BookAppointmentAsync(appointmentDto);
        return CreatedAtAction(nameof(GetAppointment), new { id = appointment.Id }, appointment);
    }

    [HttpGet("patient/{patientId}")]
    public async Task<IActionResult> GetPatientAppointments(Guid patientId)
    {
        var appointments = await _appointmentService.GetPatientAppointmentsAsync(patientId);
        return Ok(appointments);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAppointment(Guid id)
    {
        var appointment = await _appointmentService.GetByIdAsync(id);
        return Ok(appointment);
    }

    [HttpPost("{appointmentId}/cancel")]
    public async Task<IActionResult> CancelAppointment(Guid appointmentId)
    {
        await _appointmentService.CancelAppointmentAsync(appointmentId);
        return NoContent();
    }

    [HttpPost("{appointmentId}/confirm")]
    public async Task<IActionResult> ConfirmAppointment(Guid appointmentId)
    {
        await _appointmentService.ConfirmAppointmentAsync(appointmentId);
        return NoContent();
    }
}
}
