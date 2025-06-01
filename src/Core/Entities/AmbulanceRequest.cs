namespace Core.Entities{
   public class AmbulanceRequest
{
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; }
    public string PickupLocation { get; set; }
    public string Destination { get; set; }
    public string EmergencyContact { get; set; }
    public string? Notes { get; set; }
    public DateTime RequestTime { get; set; } = DateTime.UtcNow;
    public AmbulanceStatus Status { get; set; } = AmbulanceStatus.Pending;
}
}