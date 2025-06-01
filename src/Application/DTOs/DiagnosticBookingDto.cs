namespace Application.DTOs{
    public class DiagnosticBookingDto
{
    public Guid PatientId { get; set; }
    public DiagnosticType DiagnosticType { get; set; }
    public DateTime BookingDate { get; set; }
    public TimeSlot TimeSlot { get; set; }
    public string? Notes { get; set; }
}
}