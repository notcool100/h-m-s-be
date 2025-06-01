
namespace Core.Entities
{
    public class PharmacyOrder
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int? PrescriptionId { get; set; }
        public string OrderStatus { get; set; } // e.g., Processing, Shipped, Delivered
        public string DeliverySlot { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
