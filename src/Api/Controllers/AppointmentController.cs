using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Core.Entities;
using System.Collections.Generic;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet("{id}")]
        public ActionResult<Appointment> Get(int id)
        {
            var appointment = _appointmentService.GetAppointmentById(id);
            if (appointment == null)
                return NotFound();
            return Ok(appointment);
        }

        [HttpGet("patient/{patientId}")]
        public ActionResult<IEnumerable<Appointment>> GetByPatient(int patientId)
        {
            var appointments = _appointmentService.GetAppointmentsByPatientId(patientId);
            return Ok(appointments);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Appointment appointment)
        {
            _appointmentService.AddAppointment(appointment);
            return CreatedAtAction(nameof(Get), new { id = appointment.Id }, appointment);
        }
    }
}
