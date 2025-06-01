using System;

namespace Core.Entities
{
  public class Appointment
{
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; }
    public Guid DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    public DateTime AppointmentDate { get; set; }
    public TimeSlot TimeSlot { get; set; }
    public string? Symptoms { get; set; }
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;
}

}
