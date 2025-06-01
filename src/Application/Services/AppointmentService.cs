using System.Collections.Generic;
using Core.Entities;
using Application.Interface;

namespace Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public Appointment GetAppointmentById(int id)
        {
            return _appointmentRepository.GetById(id);
        }

        public IEnumerable<Appointment> GetAppointmentsByPatientId(int patientId)
        {
            return _appointmentRepository.GetByPatientId(patientId);
        }

        public void AddAppointment(Appointment appointment)
        {
            _appointmentRepository.Add(appointment);
        }
    }
}
