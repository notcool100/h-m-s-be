using System.Collections.Generic;
using Application.Dto;

namespace Application.Interface{
    public interface IDiagnosticService
{
    Task<DiagnosticBooking> BookDiagnosticTestAsync(DiagnosticBookingDto bookingDto);
    Task<IEnumerable<DiagnosticBooking>> GetPatientDiagnosticBookingsAsync(Guid patientId);
    Task UploadDiagnosticReportAsync(Guid bookingId, string reportUrl);
    Task CancelDiagnosticBookingAsync(Guid bookingId);
}
}