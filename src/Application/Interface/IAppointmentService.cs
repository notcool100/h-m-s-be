using System.Collections.Generic;
using Application.Dto;

namespace Application.Interface
{
    public interface IAppointmentService
    {
        Task<Appointment> BookAppointmentAsync(AppointmentRequestDto appointmentDto);
    Task<IEnumerable<Appointment>> GetPatientAppointmentsAsync(Guid patientId);
    Task CancelAppointmentAsync(Guid appointmentId);
    Task ConfirmAppointmentAsync(Guid appointmentId);
    }
}
