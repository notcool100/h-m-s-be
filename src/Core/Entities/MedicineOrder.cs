namespace Core.Entities{
public class MedicineOrder
{
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; }
    public string PrescriptionUrl { get; set; }
    public string DeliveryAddress { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Processing;
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public DateTime? DeliveryDate { get; set; }
    public string? TrackingNumber { get; set; }
    public decimal TotalAmount { get; set; }
    public DeliveryMethod DeliveryMethod { get; set; }
}
}