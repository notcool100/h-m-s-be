using Microsoft.EntityFrameworkCore;
using Core.Entities;

namespace Infrastructure.Data
{
    public class HealthBridgeDbContext : DbContext
    {
        public HealthBridgeDbContext(DbContextOptions<HealthBridgeDbContext> options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PharmacyOrder> PharmacyOrders { get; set; }
        public DbSet<DiagnosticTest> DiagnosticTests { get; set; }
        public DbSet<AmbulanceService> AmbulanceServices { get; set; }
    }
}
