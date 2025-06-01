using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Core.Entities;
using System.Collections.Generic;

namespace Api.Controllers
{
   [ApiController]
[Route("api/[controller]")]
public class PatientController : ControllerBase
{
    private readonly IPatientService _patientService;

    public PatientController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPatient(Guid id)
    {
        var patient = await _patientService.GetPatientByIdAsync(id);
        return Ok(patient);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePatient([FromBody] PatientDto patientDto)
    {
        var createdPatient = await _patientService.CreatePatientAsync(patientDto);
        return CreatedAtAction(nameof(GetPatient), new { id = createdPatient.Id }, createdPatient);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePatient(Guid id, [FromBody] PatientDto patientDto)
    {
        await _patientService.UpdatePatientAsync(id, patientDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePatient(Guid id)
    {
        await _patientService.DeletePatientAsync(id);
        return NoContent();
    }
}
}
