namespace Core.Entities{
public class DiagnosticBooking
{
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; }
    public DiagnosticType DiagnosticType { get; set; }
    public DateTime BookingDate { get; set; }
    public TimeSlot TimeSlot { get; set; }
    public string? Notes { get; set; }
    public string? ReportUrl { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DiagnosticStatus Status { get; set; } = DiagnosticStatus.Pending;
}
}