namespace Application.DTOs
{
   public class AmbulanceRequestDto
{
    public Guid PatientId { get; set; }
    public string PickupLocation { get; set; }
    public string Destination { get; set; }
    public string EmergencyContact { get; set; }
    public string? Notes { get; set; }
}}