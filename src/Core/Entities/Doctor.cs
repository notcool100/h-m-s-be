namespace Core.Entities
{
   public class Doctor
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string Specialization { get; set; }
    public string Location { get; set; }
    public string? ContactNumber { get; set; }
    public string? Email { get; set; }
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
}
