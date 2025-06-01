using System.Collections.Generic;
using Application.Dto;
using Application.Interface;

namespace Application.Services
{
   public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly IDoctorRepository _doctorRepository;
    private readonly INotificationService _notificationService;
    private readonly IMapper _mapper;

    public AppointmentService(
        IAppointmentRepository appointmentRepository,
        IPatientRepository patientRepository,
        IDoctorRepository doctorRepository,
        INotificationService notificationService,
        IMapper mapper)
    {
        _appointmentRepository = appointmentRepository;
        _patientRepository = patientRepository;
        _doctorRepository = doctorRepository;
        _notificationService = notificationService;
        _mapper = mapper;
    }

    public async Task<Appointment> BookAppointmentAsync(AppointmentRequestDto appointmentDto)
    {
        var patient = await _patientRepository.GetByIdAsync(appointmentDto.PatientId);
        var doctor = await _doctorRepository.GetByIdAsync(appointmentDto.DoctorId);
        
        if (patient == null || doctor == null)
        {
            throw new Exception("Patient or Doctor not found");
        }

        var appointment = _mapper.Map<Appointment>(appointmentDto);
        appointment = await _appointmentRepository.AddAsync(appointment);

        // Send notification
        await _notificationService.SendNotificationAsync(
            appointmentDto.PatientId,
            "Appointment Booked",
            $"Your appointment with Dr. {doctor.FullName} is booked for {appointment.AppointmentDate.ToShortDateString()}",
            NotificationType.AppointmentConfirmation);

        return appointment;
    }

    public async Task<IEnumerable<Appointment>> GetPatientAppointmentsAsync(Guid patientId)
    {
        return await _appointmentRepository.GetByPatientIdAsync(patientId);
    }

    public async Task CancelAppointmentAsync(Guid appointmentId)
    {
        var appointment = await _appointmentRepository.GetByIdAsync(appointmentId);
        appointment.Status = AppointmentStatus.Cancelled;
        await _appointmentRepository.UpdateAsync(appointment);

        // Send notification
        await _notificationService.SendNotificationAsync(
            appointment.PatientId,
            "Appointment Cancelled",
            $"Your appointment with Dr. {appointment.Doctor.FullName} has been cancelled",
            NotificationType.AppointmentConfirmation);
    }

    public async Task ConfirmAppointmentAsync(Guid appointmentId)
    {
        var appointment = await _appointmentRepository.GetByIdAsync(appointmentId);
        appointment.Status = AppointmentStatus.Confirmed;
        await _appointmentRepository.UpdateAsync(appointment);

        // Send notification
        await _notificationService.SendNotificationAsync(
            appointment.PatientId,
            "Appointment Confirmed",
            $"Your appointment with Dr. {appointment.Doctor.FullName} is confirmed for {appointment.AppointmentDate.ToShortDateString()}",
            NotificationType.AppointmentConfirmation);
    }
}
}
