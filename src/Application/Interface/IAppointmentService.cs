using System.Collections.Generic;
using Core.Entities;

namespace Application.Interface
{
    public interface IAppointmentService
    {
        Appointment GetAppointmentById(int id);
        IEnumerable<Appointment> GetAppointmentsByPatientId(int patientId);
        void AddAppointment(Appointment appointment);
    }
}
