using System.Collections.Generic;
using Core.Entities;

namespace Infrastructure.Data.Interfaces
{
    public interface IPatientRepository
    {
        Patient GetById(int id);
        IEnumerable<Patient> GetAll();
        void Add(Patient patient);
    }
}
