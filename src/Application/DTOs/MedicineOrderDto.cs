namespace Application.DTOs{
    public class MedicineOrderDto
{
    public Guid PatientId { get; set; }
    public string PrescriptionUrl { get; set; }
    public string DeliveryAddress { get; set; }
    public DeliveryMethod DeliveryMethod { get; set; }
}
}