using System;

namespace Core.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string TimeSlot { get; set; }
        public string Symptoms { get; set; }
        public string Status { get; set; } // e.g., Scheduled, Completed, Cancelled
        public int? PrescriptionId { get; set; }
    }
}
