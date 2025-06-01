namespace Application.DTOs{
    public class InquiryDto
{
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public string? Email { get; set; }
    public InquiryType InquiryType { get; set; }
    public string Message { get; set; }
}
}