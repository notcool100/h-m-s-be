using System.Collections.Generic;
using Application.Dto;

namespace Application.Services
{
    public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;
    private readonly IMapper _mapper;

    public PatientService(IPatientRepository patientRepository, IMapper mapper)
    {
        _patientRepository = patientRepository;
        _mapper = mapper;
    }

    public async Task<PatientDto> GetPatientByIdAsync(Guid id)
    {
        var patient = await _patientRepository.GetByIdAsync(id);
        return _mapper.Map<PatientDto>(patient);
    }

    public async Task<PatientDto> CreatePatientAsync(PatientDto patientDto)
    {
        var patient = _mapper.Map<Patient>(patientDto);
        patient = await _patientRepository.AddAsync(patient);
        return _mapper.Map<PatientDto>(patient);
    }

    public async Task UpdatePatientAsync(Guid id, PatientDto patientDto)
    {
        var patient = await _patientRepository.GetByIdAsync(id);
        _mapper.Map(patientDto, patient);
        await _patientRepository.UpdateAsync(patient);
    }

    public async Task DeletePatientAsync(Guid id)
    {
        await _patientRepository.DeleteAsync(id);
    }
}

}
