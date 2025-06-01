using System.Collections.Generic;
using Core.Entities;

namespace Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly List<Patient> _patients = new List<Patient>();

        public Patient GetPatientById(int id)
        {
            return _patients.Find(p => p.Id == id);
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            return _patients;
        }

        public void AddPatient(Patient patient)
        {
            _patients.Add(patient);
        }
    }
}
