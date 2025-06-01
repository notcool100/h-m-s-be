namespace Application.DTOs{
    public class AppointmentRequestDto
{
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
    public DateTime AppointmentDate { get; set; }
    public TimeSlot TimeSlot { get; set; }
    public string? Symptoms { get; set; }
}
}