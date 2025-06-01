using System.Collections.Generic;
using Application.Dto;
namespace Application.Interface{
    public interface IInquiryService
{
    Task<Inquiry> CreateInquiryAsync(InquiryDto inquiryDto);
    Task<IEnumerable<Inquiry>> GetAllInquiriesAsync();
    Task MarkInquiryAsResolvedAsync(Guid inquiryId);
}
}