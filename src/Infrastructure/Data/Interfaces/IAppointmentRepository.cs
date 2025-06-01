using System.Collections.Generic;
using Core.Entities;

namespace Infrastructure.Data.Interfaces
{
    public interface IAppointmentRepository
    {
        Appointment GetById(int id);
        IEnumerable<Appointment> GetByPatientId(int patientId);
        void Add(Appointment appointment);
    }
}
