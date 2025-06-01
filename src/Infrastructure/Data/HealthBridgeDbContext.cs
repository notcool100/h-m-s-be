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
    public DbSet<DiagnosticBooking> DiagnosticBookings { get; set; }
    public DbSet<MedicineOrder> MedicineOrders { get; set; }
    public DbSet<Inquiry> Inquiries { get; set; }
    public DbSet<AmbulanceRequest> AmbulanceRequests { get; set; }
    public DbSet<PrescriptionUpload> PrescriptionUploads { get; set; }
    public DbSet<Notification> Notifications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Configure relationships and indexes
        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Patient)
            .WithMany(p => p.Appointments)
            .HasForeignKey(a => a.PatientId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Doctor)
            .WithMany(d => d.Appointments)
            .HasForeignKey(a => a.DoctorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<DiagnosticBooking>()
            .HasOne(d => d.Patient)
            .WithMany(p => p.DiagnosticBookings)
            .HasForeignKey(d => d.PatientId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<MedicineOrder>()
            .HasOne(m => m.Patient)
            .WithMany(p => p.MedicineOrders)
            .HasForeignKey(m => m.PatientId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<AmbulanceRequest>()
            .HasOne(a => a.Patient)
            .WithMany()
            .HasForeignKey(a => a.PatientId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<PrescriptionUpload>()
            .HasOne(p => p.Patient)
            .WithMany()
            .HasForeignKey(p => p.PatientId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Notification>()
            .HasIndex(n => n.UserId);
    }
}

// Infrastructure/Data/Interfaces/IPatientRepository.cs
public interface IPatientRepository
{
    Task<Patient> GetByIdAsync(Guid id);
    Task<Patient> GetByPhoneNumberAsync(string phoneNumber);
    Task<Patient> AddAsync(Patient patient);
    Task UpdateAsync(Patient patient);
    Task DeleteAsync(Guid id);
}

// Infrastructure/Data/Interfaces/IAppointmentRepository.cs
public interface IAppointmentRepository
{
    Task<Appointment> GetByIdAsync(Guid id);
    Task<IEnumerable<Appointment>> GetByPatientIdAsync(Guid patientId);
    Task<Appointment> AddAsync(Appointment appointment);
    Task UpdateAsync(Appointment appointment);
    Task DeleteAsync(Guid id);
}

// Infrastructure/Data/Repositories/PatientRepository.cs
public class PatientRepository : IPatientRepository
{
    private readonly HealthBridgeDbContext _context;

    public PatientRepository(HealthBridgeDbContext context)
    {
        _context = context;
    }

    public async Task<Patient> GetByIdAsync(Guid id)
    {
        return await _context.Patients.FindAsync(id);
    }

    public async Task<Patient> GetByPhoneNumberAsync(string phoneNumber)
    {
        return await _context.Patients.FirstOrDefaultAsync(p => p.PhoneNumber == phoneNumber);
    }

    public async Task<Patient> AddAsync(Patient patient)
    {
        await _context.Patients.AddAsync(patient);
        await _context.SaveChangesAsync();
        return patient;
    }

    public async Task UpdateAsync(Patient patient)
    {
        _context.Patients.Update(patient);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var patient = await GetByIdAsync(id);
        if (patient != null)
        {
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
        }
    }
}

// Infrastructure/Data/Repositories/AppointmentRepository.cs
public class AppointmentRepository : IAppointmentRepository
{
    private readonly HealthBridgeDbContext _context;

    public AppointmentRepository(HealthBridgeDbContext context)
    {
        _context = context;
    }

    public async Task<Appointment> GetByIdAsync(Guid id)
    {
        return await _context.Appointments
            .Include(a => a.Patient)
            .Include(a => a.Doctor)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<IEnumerable<Appointment>> GetByPatientIdAsync(Guid patientId)
    {
        return await _context.Appointments
            .Include(a => a.Doctor)
            .Where(a => a.PatientId == patientId)
            .OrderByDescending(a => a.AppointmentDate)
            .ToListAsync();
    }

    public async Task<Appointment> AddAsync(Appointment appointment)
    {
        await _context.Appointments.AddAsync(appointment);
        await _context.SaveChangesAsync();
        return appointment;
    }

    public async Task UpdateAsync(Appointment appointment)
    {
        _context.Appointments.Update(appointment);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var appointment = await GetByIdAsync(id);
        if (appointment != null)
        {
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
        }
    }
}
}
