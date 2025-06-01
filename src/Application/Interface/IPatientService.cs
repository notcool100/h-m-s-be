using System.Collections.Generic;
using Core.Entities;

namespace Application.Interface
{
    public interface IPatientService
    {
        Patient GetPatientById(int id);
        IEnumerable<Patient> GetAllPatients();
        void AddPatient(Patient patient);
    }
}
