using Application.Dto;
namespace Application.Validators{
   public class InquiryValidator : AbstractValidator<InquiryDto>
{
    public InquiryValidator()
    {
        RuleFor(x => x.FullName).NotEmpty().MaximumLength(100);
        RuleFor(x => x.PhoneNumber).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Email).MaximumLength(100).EmailAddress().When(x => !string.IsNullOrEmpty(x.Email));
        RuleFor(x => x.InquiryType).IsInEnum();
        RuleFor(x => x.Message).NotEmpty().MaximumLength(1000);
    }
}
}