using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Core.Entities;
using System.Collections.Generic;

namespace Api.Controllers
{
  [ApiController]
[Route("api/[controller]")]
[Authorize]
public class DiagnosticController : ControllerBase
{
    private readonly IDiagnosticService _diagnosticService;

    public DiagnosticController(IDiagnosticService diagnosticService)
    {
        _diagnosticService = diagnosticService;
    }

    [HttpPost]
    public async Task<IActionResult> BookDiagnosticTest([FromBody] DiagnosticBookingDto bookingDto)
    {
        var booking = await _diagnosticService.BookDiagnosticTestAsync(bookingDto);
        return CreatedAtAction(nameof(GetDiagnosticBooking), new { id = booking.Id }, booking);
    }

    [HttpGet("patient/{patientId}")]
    public async Task<IActionResult> GetPatientDiagnosticBookings(Guid patientId)
    {
        var bookings = await _diagnosticService.GetPatientDiagnosticBookingsAsync(patientId);
        return Ok(bookings);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDiagnosticBooking(Guid id)
    {
        var booking = await _diagnosticService.GetByIdAsync(id);
        return Ok(booking);
    }

    [HttpPost("{bookingId}/upload-report")]
    public async Task<IActionResult> UploadDiagnosticReport(Guid bookingId, [FromBody] string reportUrl)
    {
        await _diagnosticService.UploadDiagnosticReportAsync(bookingId, reportUrl);
        return NoContent();
    }

    [HttpPost("{bookingId}/cancel")]
    public async Task<IActionResult> CancelDiagnosticBooking(Guid bookingId)
    {
        await _diagnosticService.CancelDiagnosticBookingAsync(bookingId);
        return NoContent();
    }
}
}
