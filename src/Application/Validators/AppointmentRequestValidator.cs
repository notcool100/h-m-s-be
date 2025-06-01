using Application.Dto;
namespace Application.Validators{
    public class AppointmentRequestValidator : AbstractValidator<AppointmentRequestDto>
{
    public AppointmentRequestValidator()
    {
        RuleFor(x => x.PatientId).NotEmpty();
        RuleFor(x => x.DoctorId).NotEmpty();
        RuleFor(x => x.AppointmentDate)
            .NotEmpty()
            .GreaterThanOrEqualTo(DateTime.Today)
            .WithMessage("Appointment date must be today or in the future");
        RuleFor(x => x.TimeSlot).IsInEnum();
        RuleFor(x => x.Symptoms).MaximumLength(500);
    }
}
}