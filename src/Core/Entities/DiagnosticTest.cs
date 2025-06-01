using System;

namespace Core.Entities
{
    public class DiagnosticTest
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string TestType { get; set; } // e.g., MRI, CT, USG, Blood Test
        public int AppointmentId { get; set; }
        public string Status { get; set; } // e.g., Scheduled, Completed
        public string ReportFilePath { get; set; }
    }
}
