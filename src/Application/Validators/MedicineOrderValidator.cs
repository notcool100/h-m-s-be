using Application.Dto;
namespace Application.Validators{
   public class MedicineOrderValidator : AbstractValidator<MedicineOrderDto>
{
    public MedicineOrderValidator()
    {
        RuleFor(x => x.PatientId).NotEmpty();
        RuleFor(x => x.PrescriptionUrl).NotEmpty().MaximumLength(500);
        RuleFor(x => x.DeliveryAddress).NotEmpty().MaximumLength(200);
        RuleFor(x => x.DeliveryMethod).IsInEnum();
    }
}
}