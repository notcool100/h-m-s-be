namespace Core.Entities
{
    public class Patient
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public int Age { get; set; }
    public Gender Gender { get; set; }
    public string PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    public ICollection<DiagnosticBooking> DiagnosticBookings { get; set; } = new List<DiagnosticBooking>();
    public ICollection<MedicineOrder> MedicineOrders { get; set; } = new List<MedicineOrder>();
}
}
