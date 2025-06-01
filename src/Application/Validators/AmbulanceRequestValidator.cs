using Application.Dto;
namespace Application.Validators{
    public class AmbulanceRequestValidator : AbstractValidator<AmbulanceRequestDto>
{
    public AmbulanceRequestValidator()
    {
        RuleFor(x => x.PatientId).NotEmpty();
        RuleFor(x => x.PickupLocation).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Destination).NotEmpty().MaximumLength(200);
        RuleFor(x => x.EmergencyContact).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Notes).MaximumLength(500);
    }
}
}