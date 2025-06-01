using System.Collections.Generic;
using Application.Dto;

namespace Application.Interface
{
    public interface IPatientService
    {
        Task<PatientDto> GetPatientByIdAsync(Guid id);
    Task<PatientDto> CreatePatientAsync(PatientDto patientDto);
    Task UpdatePatientAsync(Guid id, PatientDto patientDto);
    Task DeletePatientAsync(Guid id);
    }
}
