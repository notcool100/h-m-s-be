using System;

namespace Core.Entities
{
    public class Prescription
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int AppointmentId { get; set; }
        public string FilePath { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
