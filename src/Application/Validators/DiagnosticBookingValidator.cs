using Application.Dto;
namespace Application.Validators{
 public class DiagnosticBookingValidator : AbstractValidator<DiagnosticBookingDto>
{
    public DiagnosticBookingValidator()
    {
        RuleFor(x => x.PatientId).NotEmpty();
        RuleFor(x => x.DiagnosticType).IsInEnum();
        RuleFor(x => x.BookingDate)
            .NotEmpty()
            .GreaterThanOrEqualTo(DateTime.Today)
            .WithMessage("Booking date must be today or in the future");
        RuleFor(x => x.TimeSlot).IsInEnum();
        RuleFor(x => x.Notes).MaximumLength(500);
    }
}
}