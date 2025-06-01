using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Core.Entities;
using System.Collections.Generic;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet("{id}")]
        public ActionResult<Patient> Get(int id)
        {
            var patient = _patientService.GetPatientById(id);
            if (patient == null)
                return NotFound();
            return Ok(patient);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Patient>> GetAll()
        {
            var patients = _patientService.GetAllPatients();
            return Ok(patients);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Patient patient)
        {
            _patientService.AddPatient(patient);
            return CreatedAtAction(nameof(Get), new { id = patient.Id }, patient);
        }
    }
}
