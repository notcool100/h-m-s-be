namespace Application.DTOs
{
    public class PatientDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public int Age { get; set; }
    public Gender Gender { get; set; }
    public string PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
}
    }