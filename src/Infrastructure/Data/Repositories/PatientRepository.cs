using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using Infrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly HealthBridgeDbContext _context;

        public PatientRepository(HealthBridgeDbContext context)
        {
            _context = context;
        }

        public Patient GetById(int id)
        {
            return _context.Patients.Find(id);
        }

        public IEnumerable<Patient> GetAll()
        {
            return _context.Patients.ToList();
        }

        public void Add(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
        }
    }
}
