using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using Infrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly HealthBridgeDbContext _context;

        public AppointmentRepository(HealthBridgeDbContext context)
        {
            _context = context;
        }

        public Appointment GetById(int id)
        {
            return _context.Appointments.Find(id);
        }

        public IEnumerable<Appointment> GetByPatientId(int patientId)
        {
            return _context.Appointments.Where(a => a.PatientId == patientId).ToList();
        }

        public void Add(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
        }
    }
}
