using System.Collections.Generic;
using Application.Dto;
using Application.Interface;

namespace Application.Services
{
   public class DiagnosticService : IDiagnosticService
{
    private readonly IDiagnosticBookingRepository _bookingRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly INotificationService _notificationService;
    private readonly IMapper _mapper;

    public DiagnosticService(
        IDiagnosticBookingRepository bookingRepository,
        IPatientRepository patientRepository,
        INotificationService notificationService,
        IMapper mapper)
    {
        _bookingRepository = bookingRepository;
        _patientRepository = patientRepository;
        _notificationService = notificationService;
        _mapper = mapper;
    }

    public async Task<DiagnosticBooking> BookDiagnosticTestAsync(DiagnosticBookingDto bookingDto)
    {
        var patient = await _patientRepository.GetByIdAsync(bookingDto.PatientId);
        if (patient == null)
        {
            throw new Exception("Patient not found");
        }

        var booking = _mapper.Map<DiagnosticBooking>(bookingDto);
        booking = await _bookingRepository.AddAsync(booking);

        // Send notification
        await _notificationService.SendNotificationAsync(
            bookingDto.PatientId,
            "Diagnostic Test Booked",
            $"Your {bookingDto.DiagnosticType} test is booked for {bookingDto.BookingDate.ToShortDateString()}",
            NotificationType.DiagnosticBooking);

        return booking;
    }

    public async Task<IEnumerable<DiagnosticBooking>> GetPatientDiagnosticBookingsAsync(Guid patientId)
    {
        return await _bookingRepository.GetByPatientIdAsync(patientId);
    }

    public async Task UploadDiagnosticReportAsync(Guid bookingId, string reportUrl)
    {
        var booking = await _bookingRepository.GetByIdAsync(bookingId);
        booking.ReportUrl = reportUrl;
        booking.Status = DiagnosticStatus.Completed;
        await _bookingRepository.UpdateAsync(booking);

        // Send notification
        await _notificationService.SendNotificationAsync(
            booking.PatientId,
            "Diagnostic Report Available",
            $"Your {booking.DiagnosticType} report is now available",
            NotificationType.DiagnosticBooking);
    }

    public async Task CancelDiagnosticBookingAsync(Guid bookingId)
    {
        var booking = await _bookingRepository.GetByIdAsync(bookingId);
        booking.Status = DiagnosticStatus.Cancelled;
        await _bookingRepository.UpdateAsync(booking);

        // Send notification
        await _notificationService.SendNotificationAsync(
            booking.PatientId,
            "Diagnostic Booking Cancelled",
            $"Your {booking.DiagnosticType} test booking has been cancelled",
            NotificationType.DiagnosticBooking);
    }
}
}
