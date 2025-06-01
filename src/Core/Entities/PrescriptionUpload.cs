namespace Core.Entities{
public class PrescriptionUpload
{
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; }
    public string FileUrl { get; set; }
    public DateTime UploadDate { get; set; } = DateTime.UtcNow;
    public bool IsProcessed { get; set; } = false;
}
}